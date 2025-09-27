using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class SubspeciesDuplicationButton : PowerboxGodPowerButtonFeature<SubspeciesDuplicationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(SubspeciesCreationButton);
    public override string SpritePath => "ui/icons/iconsubspecieslist";

    protected override TabSection Section => TabSection.Metas;
  }
}
