using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class CultureBorderExpansionButton : GodPowerButtonFeature<CultureBorderExpansionPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(CityBorderReductionButton);
    public override string SpritePath => "powers/culture_borders_plus";
  }
}
