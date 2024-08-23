using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class NonRandomFriendshipButton : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(NonRandomFriendshipPower) }).ToList();
    internal override FeatureRequirementList OptionalFeatures => new List<Type>{ typeof(ClanAdditionButton) };
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
