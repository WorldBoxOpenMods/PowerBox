using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class CityBorderReductionPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      GodPower reduceCityBorders = new GodPower {
        id = "powerbox_reduce_city_borders",
        name = "powerbox_reduce_city_borders",
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = true,
        show_tool_sizes = false,
        unselect_when_window = true,
        click_special_action = CityBorderReductionAction
      };
      return reduceCityBorders;
    }

    private static bool CityBorderReductionAction(WorldTile pTile = null, string pPowerId = null) {
      pTile?.zone.city?.removeZone(pTile.zone);
      return true;
    }
  }
}
