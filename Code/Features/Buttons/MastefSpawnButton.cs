using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class MastefSpawnButton : GodPowerButtonFeature<MastefSpawnPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(MaximSpawnButton);
    public override string SpritePath => "ui/icons/iconMastefCreature";
  }
}
