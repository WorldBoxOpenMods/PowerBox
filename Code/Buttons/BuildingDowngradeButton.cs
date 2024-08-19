using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Buttons {
  public class BuildingDowngradeButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(GodPowers.BuildingDowngradePower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(BuildingUpgradeButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "downgradeBuildingAdd",
        Resources.Load<Sprite>("powers/downgrade_building_icon"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}