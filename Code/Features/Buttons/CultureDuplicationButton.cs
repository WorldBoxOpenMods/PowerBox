using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class CultureDuplicationButton : GodPowerButtonFeature<CultureDuplicationPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(CultureCreationButton);
    public override string SpritePath => "ui/icons/iconCloneCulture";
  }
}
