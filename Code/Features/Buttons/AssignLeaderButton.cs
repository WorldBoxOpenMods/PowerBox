using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class AssignLeaderButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new List<Type> {
      typeof(GodPowers.AssignLeaderPower)
    }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(AssignKingButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "assign_leader",
        Resources.Load<Sprite>("ui/icons/iconleaders"),
        Tab.PowerboxTabObject.transform
      );
      return true;    }
  }
}