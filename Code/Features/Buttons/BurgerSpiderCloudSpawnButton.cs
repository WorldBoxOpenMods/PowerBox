using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class BurgerSpiderCloudSpawnButton : GodPowerButtonFeature<BurgerSpiderCloudSpawnPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(BloodRainCloudSpawnButton);
    public override string SpritePath => "powers/burgerspider_rain";
  }
}
