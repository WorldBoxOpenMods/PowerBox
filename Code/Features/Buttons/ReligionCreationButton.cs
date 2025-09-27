using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class ReligionCreationButton : PowerboxGodPowerButtonFeature<ReligionCreationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(LanguageAdditionButton);
    public override string SpritePath => "ui/icons/iconreligion";

    protected override TabSection Section => TabSection.Metas;
  }
}
