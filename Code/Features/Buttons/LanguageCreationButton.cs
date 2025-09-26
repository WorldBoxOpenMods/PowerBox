using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class LanguageCreationButton : PowerboxGodPowerButtonFeature<LanguageCreationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(CultureAdditionButton);
    public override string SpritePath => "ui/icons/iconlanguage";

    public override TabSection Section => TabSection.Metas;
  }
}
