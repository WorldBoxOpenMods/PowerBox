using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class AssignCapitalButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new List<Type> {
      typeof(GodPowers.AssignCapitalPower)
    }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(NonRandomFriendshipButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "assign_capital",
        Resources.Load<Sprite>("ui/icons/iconkingdom"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}