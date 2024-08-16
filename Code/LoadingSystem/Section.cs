using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.LoadingSystem {
  public abstract class Section {
    private List<Feature> _cachedFeatures;
    internal Feature[] GetFeatures() {
      if (!(_cachedFeatures is null)) {
        return _cachedFeatures.ToArray();
      }
      List<Feature> features = new List<Feature>();
      foreach ((Type featureType, Feature instance) in GetType().Module.GetTypes().Where(t => (t.Namespace ?? "").Contains((GetType().Namespace ?? throw new Exception($"Can't get namespace of Section type {GetType().FullName}")) + ".Features")).Where(t => typeof(Feature).IsAssignableFrom(t)).Select(featureType => (featureType, featureType.GetConstructors().FirstOrDefault(constructor => !constructor.IsPublic && constructor.GetParameters().Length < 1))).Select(tc => (tc.featureType, tc.Item2?.Invoke(new object[]{}) as Feature))) {
        if (instance is null) {
          Debug.LogError($"Instance of Feature {featureType.FullName} couldn't be created due to missing non public 0 param constructor!");
        } else {
          features.Add(instance);
        }
      }
      _cachedFeatures = features;
      return features.ToArray();
    }
  }
}