using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class CultureBorderReductionPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "reduceCultureBorders",
        name = "reduceCultureBorders",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CultureBorderReductionAction
      };
    }
    
    private static bool CultureBorderReductionAction(WorldTile pTile = null, string pPowerId = null) {
      pTile?.zone.culture?.removeZone(pTile.zone);
      return true;
    }
  }
}
