using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class GregSpawnButton : GodPowerButtonFeature<GregSpawnPower, Tab> {
    public override string SpritePath => "ui/icons/icongreg";
    internal override FeatureRequirementList OptionalFeatures => typeof(BurgerSpiderSpawnButton);
  }
}
