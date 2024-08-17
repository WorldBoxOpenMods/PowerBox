using System;
using System.Collections.Generic;

namespace PowerBox.Code.LoadingSystem {
  public abstract class Feature {
    internal virtual List<Type> RequiredFeatures { get; } = new List<Type>();
    internal abstract bool Init();
  }
}