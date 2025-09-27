using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class SubspeciesAdditionButton : PowerboxGodPowerButtonFeature<SubspeciesAdditionPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(SubspeciesDuplicationButton);
    public override string SpritePath => "ui/icons/iconspecieszones";

    protected override TabSection Section => TabSection.Metas;
  }
}
