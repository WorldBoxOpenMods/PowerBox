using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class BuildingDowngradeButton : GodPowerButtonFeature<BuildingDowngradePower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(BuildingUpgradeButton);
    public override string SpritePath => "powers/downgrade_building_icon";
  }
}
