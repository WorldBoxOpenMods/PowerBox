using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class ReligionDuplicationButton : PowerboxGodPowerButtonFeature<ReligionDuplicationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ReligionCreationButton);
    public override string SpritePath => "ui/icons/iconreligionlist";

    protected override TabSection Section => TabSection.Metas;
  }
}
