using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class TumorCreatureSpawnButton : ModGodPowerButtonFeature<TumorCreatureSpawnPower, Tab> {
    public override string SpritePath => "powers/tumor_unit_icon";
    public override ModFeatureRequirementList OptionalModFeatures => typeof(GregSpawnButton);
  }
}
