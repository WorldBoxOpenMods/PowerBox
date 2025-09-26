using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ArmyRemovalButton : PowerboxGodPowerButtonFeature<ArmyRemovalPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ArmyAdditionButton);
    public override string SpritePath => "ui/icons/iconarmyattackers";

    public override TabSection Section => TabSection.Metas;
  }
}
