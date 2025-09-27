using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class ArmyRemovalButton : PowerboxGodPowerButtonFeature<ArmyRemovalPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ArmyAdditionButton);
    public override string SpritePath => "ui/icons/iconarmyattackers";

    protected override TabSection Section => TabSection.Metas;
  }
}
