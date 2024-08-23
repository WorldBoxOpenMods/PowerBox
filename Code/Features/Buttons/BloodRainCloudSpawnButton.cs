using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class BloodRainCloudSpawnButton : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(BloodRainCloudSpawnPower) }).ToList();
    internal override FeatureRequirementList OptionalFeatures => new List<Type>{ typeof(TradingBoatSpawnButton) };
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