using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace PowerBox.Code.LoadingSystem {
  public class FeatureManager {
    private readonly List<Feature> _foundFeatures = new List<Feature>();
    private readonly List<Feature> _loadedFeatures = new List<Feature>();
    private FeatureManager() { }
    public static FeatureManager Instance { get; } = new FeatureManager();
    public bool IsFeatureLoaded<T>() where T : Feature {
      return IsFeatureLoaded(typeof(T));
    }

    public bool IsFeatureLoaded(Type featureType) {
      return _loadedFeatures.Any(feature => feature.GetType() == featureType);
    }

    public T GetFeature<T>(Feature askingFeature) where T : Feature {
      if (!IsFeatureLoaded<T>()) throw new InvalidOperationException($"Feature {typeof(T).FullName} is not loaded.");
      if (!askingFeature.RequiredFeatures.Contains(typeof(T))) throw new InvalidOperationException($"Feature {typeof(T).FullName} is not set as a requirement for feature {askingFeature.GetType().FullName}.");
      return (T)GetFeature(typeof(T));
    }

    private Feature GetFeature(Type featureType) {
      return _foundFeatures.FirstOrDefault(feature => feature.GetType() == featureType);
    }
    
    public bool TryGetFeature<T>(Feature askingFeature, out T feature) where T : Feature {
      if (!askingFeature.RequiredFeatures.Contains(typeof(T)) && !askingFeature.OptionalFeatures.Contains(typeof(T))) {
        feature = default;
        return false;
      }
      if (!IsFeatureLoaded<T>()) {
        feature = default;
        return false;
      }
      feature = (T)GetFeature(typeof(T));
      return true;
    }

    private class FeatureTreeNode {
      internal Feature Feature { get; }
      internal List<FeatureTreeNode> DependentFeatures { get; } = new List<FeatureTreeNode>();
      internal FeatureTreeNode(Feature feature) {
        Feature = feature;
      }
      internal static FeatureTreeNode[] CreateFeatureTrees(Feature[] features) {
        Dictionary<string, FeatureTreeNode> featureNodes = new Dictionary<string, FeatureTreeNode>();
        List<FeatureTreeNode> roots = new List<FeatureTreeNode>();
        foreach (Feature feature in features) {
          FeatureTreeNode featureTreeNode = new FeatureTreeNode(feature);
          featureNodes.Add(feature.GetType().AssemblyQualifiedName ?? throw new Exception("AssemblyQualifiedName is null, apparently."), featureTreeNode);
          if (feature.LoadAfterFeatures.Count < 1) {
            roots.Add(featureTreeNode);
          }
        }
        foreach (FeatureTreeNode node in featureNodes.Values) {
          foreach (Type requirement in node.Feature.LoadAfterFeatures) {
            if (featureNodes.TryGetValue(requirement.AssemblyQualifiedName ?? throw new Exception("AssemblyQualifiedName is null, apparently."), out FeatureTreeNode requiredNode)) {
              requiredNode.DependentFeatures.Add(node);
            }
          }
        }
        return roots.ToArray();
      }
    }

    private class FeatureLoadPathNode {
      private class PlaceholderRootFeature : Feature {
        internal override List<Type> RequiredFeatures => new List<Type>();
        internal override bool Init() {
          return true;
        }
      }
      internal Feature Feature { get; }
      internal FeatureLoadPathNode DependentFeature { get; private set; }
      internal FeatureLoadPathNode DependencyFeature { get; private set; }
      internal FeatureLoadPathNode(Feature feature) {
        Feature = feature;
      }
      [CanBeNull]
      internal static FeatureLoadPathNode CreateFeatureLoadPath(FeatureTreeNode[] featureTrees) {
        FeatureTreeNode rootTreeNode = new FeatureTreeNode(new PlaceholderRootFeature());
        foreach (FeatureTreeNode featureTree in featureTrees) {
          rootTreeNode.DependentFeatures.Add(featureTree);
        }
        FeatureLoadPathNode rootLoadPathNode = new FeatureLoadPathNode(rootTreeNode.Feature);
        FeatureLoadPathNode newestLoadPathNode = rootLoadPathNode;
        List<FeatureTreeNode> nodesToProcess = new List<FeatureTreeNode>(rootTreeNode.DependentFeatures);
        while (nodesToProcess.Count > 0) {
          FeatureTreeNode treeNode = nodesToProcess.Pop();
          FeatureLoadPathNode currentLoadPathNode = newestLoadPathNode;
          while (currentLoadPathNode != null) {
            if (currentLoadPathNode.Feature == treeNode.Feature) {
              if (currentLoadPathNode.DependentFeature != null) {
                currentLoadPathNode.DependentFeature.DependencyFeature = currentLoadPathNode.DependencyFeature;
              }
              if (currentLoadPathNode.DependencyFeature != null) {
                currentLoadPathNode.DependencyFeature.DependentFeature = currentLoadPathNode.DependentFeature;
              }
            }
            currentLoadPathNode = currentLoadPathNode.DependencyFeature;
          }
          FeatureLoadPathNode newLoadPathNode = new FeatureLoadPathNode(treeNode.Feature);
          newestLoadPathNode.DependentFeature = newLoadPathNode;
          newLoadPathNode.DependencyFeature = newestLoadPathNode;
          newestLoadPathNode = newLoadPathNode;
          nodesToProcess.AddRange(treeNode.DependentFeatures);
        }
        return rootLoadPathNode.DependentFeature;
      }
    }

    internal void Init() {
      List<Feature> features = new List<Feature>();
      foreach ((Type featureType, ConstructorInfo instanceConstructor) in GetType().Module.GetTypes().Where(t => t.IsSubclassOf(typeof(Feature))).Where(ft => !ft.IsAbstract).Where(ft => !ft.IsNestedPrivate).Select(featureType => (featureType, featureType.GetConstructors().FirstOrDefault(constructor => constructor.GetParameters().Length < 1)))) {
        Debug.Log($"Creating instance of Feature {featureType.FullName}...");
        if (instanceConstructor is null) {
          Debug.LogError($"No suitable constructor found for Feature {featureType.FullName}.");
          continue;
        }
        Feature instance;
        try {
          instance = instanceConstructor.Invoke(new object[] { }) as Feature;
        } catch (Exception e) {
          Debug.LogError($"An error occurred while trying to create an instance of Feature {featureType.FullName}:\n{e}");
          continue;
        }
        features.Add(instance);
        Debug.Log($"Successfully created instance of Feature {featureType.FullName}.");
      }
      _foundFeatures.AddRange(features);
      FeatureTreeNode[] featureTrees = FeatureTreeNode.CreateFeatureTrees(features.ToArray());
      FeatureLoadPathNode featureLoadPath = FeatureLoadPathNode.CreateFeatureLoadPath(featureTrees);
      FeatureLoadPathNode currentLoadPathNode = featureLoadPath;
      while (currentLoadPathNode != null) {
        InitFeature(currentLoadPathNode.Feature);
        currentLoadPathNode = currentLoadPathNode.DependentFeature;
      }
    }

    private void InitFeature(Feature feature) {
      Debug.Log($"Loading feature {feature.GetType().FullName}...");
      try {
        List<Type> missingRequirement = feature.RequiredFeatures.Where(requiredFeature => !IsFeatureLoaded(requiredFeature)).ToList();
        if (missingRequirement.Count > 0) {
          Debug.LogError($"Loading feature {feature.GetType().FullName} failed due missing requirement features:\n{string.Join("\n", missingRequirement.Select(type => type.FullName))}");
          return;
        }
        bool successfulInit = feature.Init();
        if (!successfulInit) {
          Debug.LogError($"Loading feature {feature.GetType().FullName} failed due to a failing condition.");
          return;
        }
        Debug.Log($"Successfully loaded feature {feature.GetType().FullName}.");
        _loadedFeatures.Add(feature);
      } catch (Exception e) {
        Debug.LogError($"An error occurred while trying to load feature {feature.GetType().FullName}:\n{e}");
      }
    }
  }
}