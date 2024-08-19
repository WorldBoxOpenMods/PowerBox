using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Buttons {
  public class NonRandomFriendshipButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(GodPowers.NonRandomFriendshipPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(ColonyCreationButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "friendshipNR",
        Resources.Load<Sprite>("ui/icons/iconfriendship"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}