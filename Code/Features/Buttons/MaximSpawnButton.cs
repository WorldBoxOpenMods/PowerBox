using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class MaximSpawnButton : PowerboxGodPowerButtonFeature<MaximSpawnPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(DebugMenuButton);
    public override string SpritePath => "ui/icons/maxim_creature";

    protected override TabSection Section => TabSection.Spawns;
  }
}
