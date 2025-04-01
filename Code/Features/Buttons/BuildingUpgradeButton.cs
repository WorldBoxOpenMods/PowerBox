using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class BuildingUpgradeButton : GodPowerButtonFeature<BuildingUpgradePower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(MushAnimalSpawnButton);
    public override string SpritePath => "powers/upgrade_building_icon";
  }
}
