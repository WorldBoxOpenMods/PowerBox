using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ArmyAdditionButton : PowerboxGodPowerButtonFeature<ArmyAdditionPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ArmyCreationButton);
    public override string SpritePath => "ui/icons/iconarmyzones";

    protected override TabSection Section => TabSection.Metas;
  }
}
