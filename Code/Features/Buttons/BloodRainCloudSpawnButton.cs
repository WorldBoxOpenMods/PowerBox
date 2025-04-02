using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class BloodRainCloudSpawnButton : ModGodPowerButtonFeature<BloodRainCloudSpawnPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(TradingBoatSpawnButton);
    public override string SpritePath => "powers/blood_rain";
  }
}
