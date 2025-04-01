using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class CultureCreationButton : GodPowerButtonFeature<CultureCreationPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(CityBorderReductionButton);
    public override string SpritePath => "ui/icons/iconculture";
  }
}
