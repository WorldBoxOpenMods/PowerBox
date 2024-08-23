using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class CultureBorderExpansionButton : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(CultureBorderExpansionPower) }).ToList();
    internal override FeatureRequirementList OptionalFeatures => new List<Type>{ typeof(CityBorderReductionButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "expandCultureBorders",
        Resources.Load<Sprite>("powers/culture_borders_plus"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}