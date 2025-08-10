using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ReligionCreationButton : ModGodPowerButtonFeature<ReligionCreationPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(LanguageCreationButton);
    public override string SpritePath => "ui/icons/iconreligion";
  }
}
