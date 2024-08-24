using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class AllianceCreationButton : GodPowerButtonFeature<AllianceCreationPower, Tab> {
    public override string SpritePath => "ui/icons/iconalliance";
    internal override FeatureRequirementList OptionalFeatures => typeof(BurgerSpiderCloudSpawnButton);
  }
}
