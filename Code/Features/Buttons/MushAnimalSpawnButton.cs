using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class MushAnimalSpawnButton : ModGodPowerButtonFeature<MushAnimalSpawnPower, Tab> {
    public override string SpritePath => "powers/mush_animal_icon";
    public override ModFeatureRequirementList OptionalModFeatures => typeof(MushCreatureSpawnButton);
  }
}
