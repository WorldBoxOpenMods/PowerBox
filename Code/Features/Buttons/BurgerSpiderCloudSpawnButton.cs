using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class BurgerSpiderCloudSpawnButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(BurgerSpiderCloudSpawnPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(BloodRainCloudSpawnButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "burgerSpiderCloudSpawn",
        Resources.Load<Sprite>("powers/burgerspider_rain"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}