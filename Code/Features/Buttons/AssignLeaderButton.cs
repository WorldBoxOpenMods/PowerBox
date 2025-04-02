using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class AssignLeaderButton : ModGodPowerButtonFeature<AssignLeaderPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(AssignKingButton);
    public override string SpritePath => "ui/icons/iconleaders";
  }
}
