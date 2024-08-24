using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class ClanAdditionButton : GodPowerButtonFeature<ClanAdditionPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(ClanCreationButton);
    public override string SpritePath => "ui/icons/iconclanzones";
  }
}
