using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ClanCreationButton : ModGodPowerButtonFeature<ClanCreationPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(AssignCapitalButton);
    public override string SpritePath => "ui/icons/iconclanlist";
  }
}
