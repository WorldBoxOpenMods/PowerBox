using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class CityConversionButton : GodPowerButtonFeature<CityConversionPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(AssignLeaderButton);
    public override string SpritePath => "ui/icons/iconcityselect";
  }
}
