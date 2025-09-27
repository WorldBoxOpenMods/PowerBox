using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class ArmyCreationButton : PowerboxGodPowerButtonFeature<ArmyCreationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(SubspeciesAdditionButton);
    public override string SpritePath => "ui/icons/iconarmy";

    protected override TabSection Section => TabSection.Metas;
  }
}
