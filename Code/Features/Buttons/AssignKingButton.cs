using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class AssignKingButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new List<Type> {
      typeof(GodPowers.AssignKingPower)
    }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(ColonyCreationButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "assign_king",
        Resources.Load<Sprite>("ui/icons/iconkings"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}