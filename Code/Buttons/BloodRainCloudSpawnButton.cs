using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Buttons {
  public class BloodRainCloudSpawnButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(GodPowers.BloodRainCloudSpawnPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(TradingBoatSpawnButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "bloodRainCloudSpawn",
        Resources.Load<Sprite>("powers/blood_rain"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}