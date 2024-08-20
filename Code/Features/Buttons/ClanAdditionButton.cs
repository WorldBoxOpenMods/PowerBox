using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class ClanAdditionButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(ClanAdditionPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(AssignCapitalButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "addToClan",
        Resources.Load<Sprite>("ui/icons/iconclanzones"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}