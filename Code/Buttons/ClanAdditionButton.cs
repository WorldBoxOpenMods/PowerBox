using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Buttons {
  public class ClanAdditionButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(GodPowers.ClanAdditionPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(NonRandomFriendshipButton) };
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