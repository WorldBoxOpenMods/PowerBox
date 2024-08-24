using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class CultureBorderReductionButton : GodPowerButtonFeature<CultureBorderReductionPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(CultureBorderExpansionButton);
    public override string SpritePath => "powers/culture_borders_minus";
  }
}
