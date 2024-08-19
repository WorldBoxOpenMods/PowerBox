using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class TransportBoatSpawnButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(TransportBoatSpawnPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(FishingBoatSpawnButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "spawn_boat_transport",
        Resources.Load<Sprite>("actors/boats/boat_trading_dwarf"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}