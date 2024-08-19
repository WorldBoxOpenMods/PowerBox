using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class CityBorderReductionButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(CityBorderReductionPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(CityBorderExpansionButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "reduceCitiesBorders",
        Resources.Load<Sprite>("powers/borders2"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}