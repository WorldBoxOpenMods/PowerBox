using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class AssignCapitalPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      GodPower assignCapital = new GodPower() {
        id = "powerbox_assign_capital",
        name = "powerbox_assign_capital",
        force_map_text = MapMode.Cities,
        click_special_action = CapitalAssignationAction
      };
      return assignCapital;
    }
    private static bool CapitalAssignationAction(WorldTile pTile, string pPowerId) {
      City city = pTile.zone.city;
      if (city == null) {
        return false;
      }
      city.kingdom.capital = city;
      city.kingdom.data.capitalID = city.data.id;
      return true;
    }
  }
}
