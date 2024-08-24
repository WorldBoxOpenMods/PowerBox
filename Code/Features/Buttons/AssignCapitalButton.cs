using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class AssignCapitalButton : GodPowerButtonFeature<AssignCapitalPower, Tab> {
    public override string SpritePath => "ui/icons/iconkingdom";
    internal override FeatureRequirementList OptionalFeatures => typeof(CityConversionButton);
  }
}
