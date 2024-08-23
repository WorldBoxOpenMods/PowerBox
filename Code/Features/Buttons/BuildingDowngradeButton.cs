using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class BuildingDowngradeButton : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(BuildingDowngradePower) }).ToList();
    internal override FeatureRequirementList OptionalFeatures => new List<Type>{ typeof(BuildingUpgradeButton) };
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