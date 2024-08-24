using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class CityBorderExpansionButton : GodPowerButtonFeature<CityBorderExpansionPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(BuildingDowngradeButton);
    public override string SpritePath => "powers/borders1";
  }
}
