using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ReligionCreationButton : PowerboxGodPowerButtonFeature<ReligionCreationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(LanguageAdditionButton);
    public override string SpritePath => "ui/icons/iconreligion";

    public override TabSection Section => TabSection.Metas;
  }
}
