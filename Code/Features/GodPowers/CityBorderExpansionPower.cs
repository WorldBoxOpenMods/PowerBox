using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class CityBorderExpansionPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      GodPower expandCityBorders = new GodPower {
        id = "powerbox_expand_city_borders",
        name = "powerbox_expand_city_borders",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CityBorderExpansionAction
      };
      return expandCityBorders;
    }
    
    private static City _toCityZone;
    private static bool CityBorderExpansionAction(WorldTile pTile = null, string pPowerId = null) {
      if (pTile?.zone.city != null) {
        _toCityZone = pTile.zone.city;
      } else {
        if (pTile != null) _toCityZone?.addZone(pTile.zone);
      }
      return true;
    }
  }
}
