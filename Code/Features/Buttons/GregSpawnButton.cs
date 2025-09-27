using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class GregSpawnButton : PowerboxGodPowerButtonFeature<GregSpawnPower> {
    public override string SpritePath => "ui/icons/icongreg";
    public override ModFeatureRequirementList OptionalModFeatures => typeof(BurgerSpiderSpawnButton);

    protected override TabSection Section => TabSection.Spawns;
  }
}
