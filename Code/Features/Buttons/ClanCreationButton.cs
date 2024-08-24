using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class ClanCreationButton : GodPowerButtonFeature<ClanCreationPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(AssignCapitalButton);
    public override string SpritePath => "ui/icons/iconclanlist";
  }
}
