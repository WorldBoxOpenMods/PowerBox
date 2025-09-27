using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class BloodRainCloudSpawnButton : PowerboxGodPowerButtonFeature<BloodRainCloudSpawnPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(GregSpawnButton);
    public override string SpritePath => "powers/blood_rain";

    protected override TabSection Section => TabSection.Spawns;
  }
}
