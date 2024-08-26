using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class CityBorderReductionPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      GodPower reduceCityBorders = new GodPower {
        id = "powerbox_reduce_city_borders",
        name = "powerbox_reduce_city_borders",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CityBorderReductionAction
      };
      return reduceCityBorders;
    }
    
    private static bool CityBorderReductionAction(WorldTile pTile = null, string pPowerId = null) {
      pTile?.zone.city?.removeZone(pTile.zone, true);
      return true;
    }
  }
}
