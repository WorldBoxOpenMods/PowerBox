using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class TumorAnimalSpawnButton : ModGodPowerButtonFeature<TumorAnimalSpawnPower, Tab> {
    public override string SpritePath => "powers/tumor_animal_icon";
    public override ModFeatureRequirementList OptionalModFeatures => typeof(TumorCreatureSpawnButton);
  }
}
