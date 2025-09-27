using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class AssignLeaderButton : PowerboxGodPowerButtonFeature<AssignLeaderPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(AssignKingButton);
    public override string SpritePath => "ui/icons/iconleaders";

    protected override TabSection Section => TabSection.Metas;
  }
}
