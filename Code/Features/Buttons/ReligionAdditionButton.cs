using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ReligionAdditionButton : PowerboxGodPowerButtonFeature<ReligionAdditionPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ReligionDuplicationButton);
    public override string SpritePath => "ui/icons/iconreligionzones";

    protected override TabSection Section => TabSection.Metas;
  }
}
