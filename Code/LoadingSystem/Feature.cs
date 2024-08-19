using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerBox.Code.LoadingSystem {
  public abstract class Feature {
    internal virtual List<Type> RequiredFeatures { get; } = new List<Type>();
    protected virtual List<Type> OptionalFeatures { get; } = new List<Type>();
    internal List<Type> LoadAfterFeatures => RequiredFeatures.Concat(OptionalFeatures).ToList();
    
    internal abstract bool Init();
  }
}