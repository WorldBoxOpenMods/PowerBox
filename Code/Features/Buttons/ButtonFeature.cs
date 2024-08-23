using System;
using System.Collections.Generic;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public abstract class ButtonFeature : Feature {
    internal override FeatureRequirementList RequiredFeatures => new List<Type> {typeof(Tab)};
    protected Tab Tab => GetFeature<Tab>();
  }
}