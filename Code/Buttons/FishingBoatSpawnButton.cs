using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Buttons {
  public class FishingBoatSpawnButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(GodPowers.FishingBoatSpawnPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(ClanAdditionButton) };
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