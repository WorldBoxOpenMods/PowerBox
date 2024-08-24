using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class AssignKingButton : GodPowerButtonFeature<AssignKingPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(ColonyCreationButton);
    public override string SpritePath => "ui/icons/iconkings";
  }
}
