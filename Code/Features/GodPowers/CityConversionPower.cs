using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class CityConversionPower : AssetFeature<GodPower> {
    public GodPower Power => Object;
    protected override GodPower InitObject() {
      return new GodPower() {
        id = "convert_city",
        name = "convert_city",
        force_map_text = MapMode.Cities,
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
          WorldTip.showNow("convert_city_no_city_selected_error", true, "top");
          return false;
        }
        Power.force_map_text = MapMode.Kingdoms;
        WorldTip.showNow("convert_city_select_kingdom", true, "top");
        return false;
      }
      _targetKingdom = pTile.zone.city?.kingdom;
      if (_targetKingdom == null) {
        WorldTip.showNow("convert_city_no_kingdom_selected_error", true, "top");
        return false;
      }
      if (_targetCity.kingdom == _targetKingdom) {
        WorldTip.showNow("convert_city_same_kingdom_error", true, "top");
        return false;
      }
      if (_targetCity.kingdom.race != _targetKingdom.race) {
        WorldTip.showNow("convert_city_different_races_error", true, "top");
        return false;
      }
      _targetCity.joinAnotherKingdom(_targetKingdom);
      return ResetPower(false);
    }

    private bool ResetPower(bool printInstructions = true) {
      _targetCity = null;
      _targetKingdom = null;
      Power.force_map_text = MapMode.Cities;
      if (printInstructions) {
        WorldTip.showNow("convert_city_select_city", true, "top");
      }
      return true;
    }
  }
}
