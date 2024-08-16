using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.LoadingSystem {
  public class FeatureManager {
    private readonly List<Section> _sections = new List<Section>();
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

    private class FeatureTreeNode {
      internal Section Section { get; }
      internal Feature Feature { get; }
      internal List<FeatureTreeNode> DependentFeatures { get; } = new List<FeatureTreeNode>();
      internal FeatureTreeNode(Section section, Feature feature) {
        Section = section;
        Feature = feature;
      }
      internal static FeatureTreeNode[] CreateFeatureTrees((Feature feature, Section section)[] features) {
        Dictionary<Type, FeatureTreeNode> featureNodes = new Dictionary<Type, FeatureTreeNode>();
        List<FeatureTreeNode> roots = new List<FeatureTreeNode>();
        foreach ((Feature feature, Section section) in features) {
          FeatureTreeNode featureTreeNode = new FeatureTreeNode(section, feature);
          featureNodes.Add(feature.GetType(), featureTreeNode);
          foreach (FeatureTreeNode root in roots.ToList()) {
            if (featureTreeNode.Feature.RequiredFeatures.Contains(root.Feature.GetType())) {
              root.DependentFeatures.Add(featureTreeNode);
            } else if (root.Feature.RequiredFeatures.Contains(featureTreeNode.Feature.GetType())) {
              featureTreeNode.DependentFeatures.Add(root);
              roots.Remove(root);
              roots.Add(featureTreeNode);
            }
          }
          foreach (FeatureTreeNode node in featureNodes.Values.Where(node => node != featureTreeNode && !roots.Contains(node))) {
            if (node.Feature.RequiredFeatures.Contains(featureTreeNode.Feature.GetType())) {
              node.DependentFeatures.Add(featureTreeNode);
            } else if (featureTreeNode.Feature.RequiredFeatures.Contains(node.Feature.GetType())) {
              featureTreeNode.DependentFeatures.Add(node);
            }
          }
        }
        return roots.ToArray();
      }
    }

    private class FeatureLoadPathNode {
      internal Section Section { get; }
      internal Feature Feature { get; }
      internal FeatureLoadPathNode DependentFeature { get; private set; }
      internal FeatureLoadPathNode DependencyFeature { get; private set; }
      internal FeatureLoadPathNode(Section section, Feature feature) {
        Section = section;
        Feature = feature;
      }
      internal static FeatureLoadPathNode CreateFeatureLoadPath(FeatureTreeNode[] featureTrees) {
        List<FeatureLoadPathNode> featurePathRootNodes = new List<FeatureLoadPathNode>();
        foreach (FeatureTreeNode featureTree in featureTrees) {
          FeatureLoadPathNode rootLoadPathNode = new FeatureLoadPathNode(featureTree.Section, featureTree.Feature);
          FeatureLoadPathNode newestLoadPathNode = rootLoadPathNode;
          featurePathRootNodes.Add(rootLoadPathNode);
          List<FeatureTreeNode> nodesToProcess = new List<FeatureTreeNode>(featureTree.DependentFeatures);
          foreach (FeatureTreeNode treeNode in nodesToProcess.ToList()) {
            nodesToProcess.Remove(treeNode);
            FeatureLoadPathNode currentLoadPathNode = newestLoadPathNode;
            while (currentLoadPathNode.DependencyFeature != null) {
              if (currentLoadPathNode.Feature == treeNode.Feature) {
                continue;
              }
              currentLoadPathNode = currentLoadPathNode.DependencyFeature;
            }
            FeatureLoadPathNode newLoadPathNode = new FeatureLoadPathNode(treeNode.Section, treeNode.Feature);
            newestLoadPathNode.DependentFeature = newLoadPathNode;
            newLoadPathNode.DependencyFeature = newestLoadPathNode;
            newestLoadPathNode = newLoadPathNode;
            nodesToProcess.AddRange(treeNode.DependentFeatures);
          }
        }
        FeatureLoadPathNode finalRootNode = featurePathRootNodes.Pop();
        while (featurePathRootNodes.Count > 0) {
          FeatureLoadPathNode rootNode = featurePathRootNodes.Pop();
          FeatureLoadPathNode lastNode = finalRootNode;
          while (lastNode.DependentFeature != null) {
            lastNode = lastNode.DependentFeature;
          }
          lastNode.DependentFeature = rootNode;
        }
        return finalRootNode;
      }
    }
    internal void Init() {
      _sections.AddRange(GetType().Module.GetTypes().Where(type => type.IsSubclassOf(typeof(Section))).Select(type => Activator.CreateInstance(type) as Section));
      (Feature feature, Section section)[] features = _sections.SelectMany(section => section.GetFeatures().Select(f => (f, section))).ToArray();
      _foundFeatures.AddRange(features.Select(t => t.feature));
      FeatureTreeNode[] featureTrees = FeatureTreeNode.CreateFeatureTrees(features);
      FeatureLoadPathNode featureLoadPath = FeatureLoadPathNode.CreateFeatureLoadPath(featureTrees);
      FeatureLoadPathNode currentLoadPathNode = featureLoadPath;
      while (currentLoadPathNode != null) {
        if (currentLoadPathNode.DependentFeature == null) {
          InitFeature(currentLoadPathNode.Feature);
        }
        currentLoadPathNode = currentLoadPathNode.DependentFeature;
      }
    }
    
    private bool InitFeature(Feature feature) {
      Debug.Log($"Loading feature {feature.GetType().FullName}...");
      try {
        if (feature.RequiredFeatures.Any(requiredFeature => !IsFeatureLoaded(requiredFeature))) {
          Debug.LogError($"Loading feature {feature.GetType().FullName} failed due a missing requirement feature.");
          return false;
        }
        bool successfulInit = feature.Init();
        if (!successfulInit) {
          Debug.LogError($"Loading feature {feature.GetType().FullName} failed due to a failing condition.");
          return false;
        }
        Debug.Log($"Successfully loaded feature {feature.GetType().FullName}.");
        _loadedFeatures.Add(feature);
        return true;
      } catch (Exception e) {
        Debug.LogError($"An error occurred while trying to load feature {feature.GetType().FullName}:\n{e}");
        return false;
      }
    }
  }
}