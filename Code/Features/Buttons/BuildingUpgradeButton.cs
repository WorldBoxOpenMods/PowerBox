using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class BuildingUpgradeButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(BuildingUpgradePower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(ItemModificationButtons) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "upgradeBuildingAdd",
        Resources.Load<Sprite>("powers/upgrade_building_icon"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}