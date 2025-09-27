using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class CityBorderExpansionPower : ModAssetFeature<GodPower> {

    private static City _toCityZone;
    protected override GodPower InitObject() {
      GodPower expandCityBorders = new GodPower {
        id = "powerbox_expand_city_borders",
        name = "powerbox_expand_city_borders",
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = true,
        show_tool_sizes = false,
        unselect_when_window = true,
        click_special_action = CityBorderExpansionAction
      };
      return expandCityBorders;
    }
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
