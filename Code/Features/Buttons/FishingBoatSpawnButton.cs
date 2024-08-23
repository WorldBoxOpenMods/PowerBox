using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class FishingBoatSpawnButton : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(FishingBoatSpawnPower) }).ToList();
    internal override FeatureRequirementList OptionalFeatures => new List<Type>{ typeof(NonRandomFriendshipButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "spawn_boat_fishing",
        Resources.Load<Sprite>("actors/boats/boat_fishing"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}
