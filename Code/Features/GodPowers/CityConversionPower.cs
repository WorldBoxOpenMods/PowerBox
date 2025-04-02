using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class CityConversionPower : ModAssetFeature<GodPower> {
    public GodPower Power => Object;
    protected override GodPower InitObject() {
      return new GodPower() {
        id = "powerbox_convert_city",
        name = "powerbox_convert_city",
        force_map_mode = MetaType.City,
        select_button_action = _ => !ResetPower(),
        click_special_action = CityConversionAction
      };
    }
    private City _targetCity;
    private Kingdom _targetKingdom;
    private bool CityConversionAction(WorldTile pTile, string pPowerId) {
      if (_targetCity == null) {
        _targetCity = pTile.zone.city;
        if (_targetCity == null) {
          WorldTip.showNow("powerbox_convert_city_no_city_selected_error", true, "top");
          return false;
        }
        Power.force_map_mode = MetaType.Kingdom;
        WorldTip.showNow("powerbox_convert_city_select_kingdom", true, "top");
        return false;
      }
      _targetKingdom = pTile.zone.city?.kingdom;
      if (_targetKingdom == null) {
        WorldTip.showNow("powerbox_convert_city_no_kingdom_selected_error", true, "top");
        return false;
      }
      if (_targetCity.kingdom == _targetKingdom) {
        WorldTip.showNow("powerbox_convert_city_same_kingdom_error", true, "top");
        return false;
      }
      _targetCity.joinAnotherKingdom(_targetKingdom);
      return ResetPower(false);
    }

    private bool ResetPower(bool printInstructions = true) {
      _targetCity = null;
      _targetKingdom = null;
      Power.force_map_mode = MetaType.City;
      if (printInstructions) {
        WorldTip.showNow("powerbox_convert_city_select_city", true, "top");
      }
      return true;
    }
  }
}
