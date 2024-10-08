using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class CultureBorderExpansionPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_expand_culture_borders",
        name = "powerbox_expand_culture_borders",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CultureBorderExpansionAction
      };
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
