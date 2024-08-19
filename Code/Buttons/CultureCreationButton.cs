using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Buttons {
  public class CultureCreationButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(GodPowers.CultureCreationPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(CultureBorderReductionButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "createCulture",
        Resources.Load<Sprite>("ui/icons/iconculture"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}