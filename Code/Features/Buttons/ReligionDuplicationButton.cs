using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ReligionDuplicationButton : ModGodPowerButtonFeature<ReligionDuplicationPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ReligionCreationButton);
    public override string SpritePath => "ui/icons/iconreligionlist";
  }
}
