using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class MaximSpawnButton : ModGodPowerButtonFeature<MaximSpawnPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(DebugMenuButton);
    public override string SpritePath => "ui/icons/iconMaximCreature";
  }
}
