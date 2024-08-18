using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.GodPowers {
  public class CultureBorderReductionPower : Feature {

    internal override bool Init() {
      GodPower reduceCultureBorders = new GodPower {
        id = "reduceCultureBorders",
        name = "reduceCultureBorders",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CultureBorderReductionAction
      };
      AssetManager.powers.add(reduceCultureBorders);
      return true;
    }
    
    private static bool CultureBorderReductionAction(WorldTile pTile = null, string pPowerId = null) {
      pTile?.zone.culture?.removeZone(pTile.zone);
      return true;
    }
  }
}