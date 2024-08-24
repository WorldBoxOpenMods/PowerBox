using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class MushCreatureSpawnButton : GodPowerButtonFeature<MushCreatureSpawnPower, Tab> {
    public override string SpritePath => "powers/mush_unit_icon";
    internal override FeatureRequirementList OptionalFeatures => typeof(TumorAnimalSpawnButton);
  }
}
