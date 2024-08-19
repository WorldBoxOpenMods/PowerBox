using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Buttons {
  public class BurgerSpiderCloudSpawnButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(GodPowers.BurgerSpiderCloudSpawnPower) }).ToList();
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