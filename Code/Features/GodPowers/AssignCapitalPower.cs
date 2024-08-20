using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class AssignCapitalPower : Feature {
    internal override bool Init() {
      GodPower assignCapital = new GodPower() {
        id = "assign_capital",
        name = "assign_capital",
        force_map_text = MapMode.Cities,
        click_special_action = CapitalAssignationAction
      };
      AssetManager.powers.add(assignCapital);
      return true;
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