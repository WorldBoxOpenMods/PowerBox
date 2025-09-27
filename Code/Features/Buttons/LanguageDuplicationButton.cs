using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class LanguageDuplicationButton : PowerboxGodPowerButtonFeature<LanguageDuplicationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(LanguageCreationButton);
    public override string SpritePath => "plots/icons/plot_language_divergence";

    protected override TabSection Section => TabSection.Metas;
  }
}
