using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class CultureBorderReductionButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(CultureBorderReductionPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(CultureBorderExpansionButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "reduceCultureBorders",
        Resources.Load<Sprite>("powers/culture_borders_minus"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}