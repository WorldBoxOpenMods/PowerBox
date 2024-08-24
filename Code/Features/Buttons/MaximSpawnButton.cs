using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class MaximSpawnButton : GodPowerButtonFeature<MaximSpawnPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(DebugMenuButton);
    public override string SpritePath => "ui/icons/iconMaximCreature";
  }
}
