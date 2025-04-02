using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class BuildingUpgradeButton : ModGodPowerButtonFeature<BuildingUpgradePower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(MushAnimalSpawnButton);
    public override string SpritePath => "powers/upgrade_building_icon";
  }
}
