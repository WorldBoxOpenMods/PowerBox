using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.GodPowers {
  public class CultureBorderExpansionPower : Feature {

    internal override bool Init() {
      GodPower expandCultureBorders = new GodPower {
        id = "expandCultureBorders",
        name = "expandCultureBorders",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CultureBorderExpansionAction
      };
      AssetManager.powers.add(expandCultureBorders);
      return true;
    }
    
    private static Culture _toCultureZone;
    private static bool CultureBorderExpansionAction(WorldTile pTile = null, string pPowerId = null) {
      if (pTile?.zone.culture != null) {
        _toCultureZone = pTile.zone.culture;
      } else {
        if (pTile != null) _toCultureZone?.addZone(pTile.zone);
      }
      return true;
    }
  }
}