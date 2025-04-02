using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class AssignKingButton : ModGodPowerButtonFeature<AssignKingPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ColonyCreationButton);
    public override string SpritePath => "ui/icons/iconkings";
  }
}
