using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class MastefSpawnButton : ModGodPowerButtonFeature<MastefSpawnPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(MaximSpawnButton);
    public override string SpritePath => "ui/icons/iconMastefCreature";
  }
}
