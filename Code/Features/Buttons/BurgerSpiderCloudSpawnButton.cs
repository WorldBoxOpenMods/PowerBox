using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class BurgerSpiderCloudSpawnButton : PowerboxGodPowerButtonFeature<BurgerSpiderCloudSpawnPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(BloodRainCloudSpawnButton);
    public override string SpritePath => "powers/burgerspider_rain";

    protected override TabSection Section => TabSection.Spawns;
  }
}
