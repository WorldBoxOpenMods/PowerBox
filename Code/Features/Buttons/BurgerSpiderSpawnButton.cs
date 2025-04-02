using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class BurgerSpiderSpawnButton : ModGodPowerButtonFeature<BurgerSpiderSpawnPower, Tab> {
    public override string SpritePath => "ui/icons/iconBurgerSpider";
    public override ModFeatureRequirementList OptionalModFeatures => typeof(MastefSpawnButton);
  }
}
