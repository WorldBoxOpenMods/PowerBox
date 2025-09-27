using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class BuildingDowngradeButton : PowerboxGodPowerButtonFeature<BuildingDowngradePower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(BuildingUpgradeButton);
    public override string SpritePath => "powers/downgrade_building";

    protected override TabSection Section => TabSection.Spawns;
  }
}
