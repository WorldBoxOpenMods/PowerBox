using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class ClanCreationButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(ClanCreationPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(AssignCapitalButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "create_clan",
        Resources.Load<Sprite>("ui/icons/iconclanlist"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}
