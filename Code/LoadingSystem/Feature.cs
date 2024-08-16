using System;
using System.Collections.Generic;

namespace PowerBox.Code.LoadingSystem {
  public abstract class Feature {
    internal abstract List<Type> RequiredFeatures { get; }
    internal abstract bool Init();
  }
}