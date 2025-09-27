using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class BurgerSpiderSpawnButton : PowerboxGodPowerButtonFeature<BurgerSpiderSpawnPower> {
    public override string SpritePath => "ui/icons/burger_spider";
    public override ModFeatureRequirementList OptionalModFeatures => typeof(MastefSpawnButton);

    protected override TabSection Section => TabSection.Spawns;
  }
}
