using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class LanguageCreationButton : ModGodPowerButtonFeature<LanguageCreationPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(CultureAdditionButton);
    public override string SpritePath => "ui/icons/iconlanguage";
  }
}
