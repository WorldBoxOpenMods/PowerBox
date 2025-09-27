using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class LanguageCreationButton : PowerboxGodPowerButtonFeature<LanguageCreationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(CultureAdditionButton);
    public override string SpritePath => "ui/icons/iconlanguage";

    protected override TabSection Section => TabSection.Metas;
  }
}
