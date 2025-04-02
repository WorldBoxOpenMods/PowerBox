using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class BurgerSpiderCloudSpawnButton : ModGodPowerButtonFeature<BurgerSpiderCloudSpawnPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(BloodRainCloudSpawnButton);
    public override string SpritePath => "powers/burgerspider_rain";
  }
}
