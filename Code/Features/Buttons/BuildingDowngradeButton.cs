using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class BuildingDowngradeButton : ModGodPowerButtonFeature<BuildingDowngradePower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(BuildingUpgradeButton);
    public override string SpritePath => "powers/downgrade_building_icon";
  }
}
