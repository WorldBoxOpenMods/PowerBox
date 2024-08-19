using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class TradingBoatSpawnButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(TradingBoatSpawnPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(TransportBoatSpawnButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "spawn_boat_trading",
        Resources.Load<Sprite>("actors/boats/boat_transport_dwarf"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}