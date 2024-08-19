using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Buttons {
  public class CultureBorderReductionButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(GodPowers.CultureBorderReductionPower) }).ToList();
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