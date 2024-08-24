using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class TumorCreatureSpawnButton : GodPowerButtonFeature<TumorCreatureSpawnPower, Tab> {
    public override string SpritePath => "powers/tumor_unit_icon";
    internal override FeatureRequirementList OptionalFeatures => typeof(GregSpawnButton);
  }
}
