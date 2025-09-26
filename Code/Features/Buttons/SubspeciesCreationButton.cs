using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class SubspeciesCreationButton : PowerboxGodPowerButtonFeature<SubspeciesCreationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ReligionAdditionButton);
    public override string SpritePath => "ui/icons/iconspecies";

    public override TabSection Section => TabSection.Metas;
  }
}
