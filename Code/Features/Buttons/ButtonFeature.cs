using System;
using System.Collections.Generic;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public abstract class ButtonFeature : Feature {
    internal override List<Type> RequiredFeatures => new List<Type> {typeof(Tab)};
    protected Tab Tab => GetFeature<Tab>();
  }
}