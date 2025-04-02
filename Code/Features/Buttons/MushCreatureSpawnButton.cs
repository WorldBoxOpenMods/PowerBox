using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class MushCreatureSpawnButton : ModGodPowerButtonFeature<MushCreatureSpawnPower, Tab> {
    public override string SpritePath => "powers/mush_unit_icon";
    public override ModFeatureRequirementList OptionalModFeatures => typeof(TumorAnimalSpawnButton);
  }
}
