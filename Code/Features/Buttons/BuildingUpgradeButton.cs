using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class BuildingUpgradeButton : PowerboxGodPowerButtonFeature<BuildingUpgradePower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(BurgerSpiderCloudSpawnButton);
    public override string SpritePath => "powers/upgrade_building";

    protected override TabSection Section => TabSection.Spawns;
  }
}
