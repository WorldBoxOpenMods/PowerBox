using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class ColonyCreationButton : GodPowerButtonFeature<ColonyCreationPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(CultureAdditionButton);
    public override string SpritePath => "powers/colonies";
  }
}
