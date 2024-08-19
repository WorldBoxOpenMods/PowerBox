using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class CultureCreationButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(CultureCreationPower) }).ToList();
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