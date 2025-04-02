using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class AllianceCreationButton : ModGodPowerButtonFeature<AllianceCreationPower, Tab> {
    public override string SpritePath => "ui/icons/iconalliance";
    public override ModFeatureRequirementList OptionalModFeatures => typeof(BurgerSpiderCloudSpawnButton);
  }
}
