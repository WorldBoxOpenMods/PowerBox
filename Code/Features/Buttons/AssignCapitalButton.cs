using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class AssignCapitalButton : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures.Concat(new List<Type> {
      typeof(GodPowers.AssignCapitalPower)
    }).ToList();
    internal override FeatureRequirementList OptionalFeatures => new List<Type>{ typeof(CityConversionButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "assign_capital",
        Resources.Load<Sprite>("ui/icons/iconkingdom"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}
