using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class LanguageAdditionButton : ModGodPowerButtonFeature<LanguageAdditionPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(LanguageDuplicationButton);
    public override string SpritePath => "ui/icons/iconlanguagezones";
  }
}
