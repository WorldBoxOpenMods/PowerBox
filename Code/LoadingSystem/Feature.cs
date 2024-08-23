using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerBox.Code.LoadingSystem {
  public abstract class Feature {
    internal virtual FeatureRequirementList RequiredFeatures { get; } = new List<Type>();
    internal virtual FeatureRequirementList OptionalFeatures { get; } = new List<Type>();
    internal List<Type> LoadAfterFeatures => RequiredFeatures.Concat(OptionalFeatures).ToList();
    
    internal abstract bool Init();
    
    protected bool TryGetFeature<T>(out T feature) where T : Feature {
      return FeatureManager.Instance.TryGetFeature(this, out feature);
    }

    protected T GetFeature<T>() where T : Feature {
      return FeatureManager.Instance.GetFeature<T>(this);
    }
    
    protected bool IsFeatureLoaded<T>() where T : Feature {
      return FeatureManager.Instance.IsFeatureLoaded<T>();
    }
  }
}
