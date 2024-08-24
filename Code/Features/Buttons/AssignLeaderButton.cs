using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class AssignLeaderButton : GodPowerButtonFeature<AssignLeaderPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(AssignKingButton);
    public override string SpritePath => "ui/icons/iconleaders";
  }
}
