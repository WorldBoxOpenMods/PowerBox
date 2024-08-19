using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class CityBorderExpansionButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(CityBorderExpansionPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(BuildingDowngradeButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "expandCitiesBorders",
        Resources.Load<Sprite>("powers/borders1"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}