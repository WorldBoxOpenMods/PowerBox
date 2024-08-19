using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Buttons {
  public class CultureBorderExpansionButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(GodPowers.CultureBorderExpansionPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(CityBorderReductionButton) };
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