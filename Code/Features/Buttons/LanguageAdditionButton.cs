using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class LanguageAdditionButton : PowerboxGodPowerButtonFeature<LanguageAdditionPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(LanguageDuplicationButton);
    public override string SpritePath => "ui/icons/iconlanguagezones";

    protected override TabSection Section => TabSection.Metas;
  }
}
