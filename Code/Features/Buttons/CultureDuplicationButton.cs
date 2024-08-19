using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class CultureDuplicationButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(CultureDuplicationPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(CultureCreationButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "duplicateCulture",
        Resources.Load<Sprite>("ui/icons/iconCloneCulture"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}