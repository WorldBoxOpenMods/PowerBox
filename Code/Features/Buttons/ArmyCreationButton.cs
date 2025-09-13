using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ArmyCreationButton : ModGodPowerButtonFeature<ArmyCreationPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(SubspeciesAdditionButton);
    public override string SpritePath => "ui/icons/iconarmy";
  }
}
