using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class BloodRainCloudSpawnButton : GodPowerButtonFeature<BloodRainCloudSpawnPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(TradingBoatSpawnButton);
    public override string SpritePath => "powers/blood_rain";
  }
}
