using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ArmyCreationButton : PowerboxGodPowerButtonFeature<ArmyCreationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(SubspeciesAdditionButton);
    public override string SpritePath => "ui/icons/iconarmy";

    public override TabSection Section => TabSection.Metas;
  }
}
