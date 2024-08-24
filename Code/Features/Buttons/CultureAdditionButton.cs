using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class CultureAdditionButton : GodPowerButtonFeature<CultureAdditionPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(CultureDuplicationButton);
    public override string SpritePath => "ui/icons/iconculturezones";
  }
}
