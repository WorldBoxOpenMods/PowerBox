using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class CityBorderReductionButton : GodPowerButtonFeature<CityBorderReductionPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(CityBorderExpansionButton);
    public override string SpritePath => "powers/borders2";
  }
}
