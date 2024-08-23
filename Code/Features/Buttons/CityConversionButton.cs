using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class CityConversionButton : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(CityConversionPower) }).ToList();
    internal override FeatureRequirementList OptionalFeatures => new List<Type>{ typeof(AssignLeaderButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "convert_city",
        Resources.Load<Sprite>("ui/icons/iconcityselect"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}
