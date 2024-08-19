using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Buttons {
  public class CultureAdditionButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(GodPowers.CultureAdditionPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(CultureDuplicationButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "addToCulture",
        Resources.Load<Sprite>("ui/icons/iconculturezones"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}