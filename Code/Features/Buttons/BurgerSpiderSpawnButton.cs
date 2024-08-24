using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class BurgerSpiderSpawnButton : GodPowerButtonFeature<BurgerSpiderSpawnPower, Tab> {
    public override string SpritePath => "ui/icons/iconBurgerSpider";
    internal override FeatureRequirementList OptionalFeatures => typeof(MastefSpawnButton);
  }
}
