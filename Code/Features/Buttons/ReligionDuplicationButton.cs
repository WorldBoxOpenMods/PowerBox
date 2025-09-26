using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ReligionDuplicationButton : PowerboxGodPowerButtonFeature<ReligionDuplicationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ReligionCreationButton);
    public override string SpritePath => "ui/icons/iconreligionlist";

    public override TabSection Section => TabSection.Metas;
  }
}
