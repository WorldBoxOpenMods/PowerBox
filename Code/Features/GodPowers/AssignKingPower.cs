using System.Linq;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class AssignKingPower : Feature {
    internal override bool Init() {
      GodPower assignKing = new GodPower() {
        id = "assign_king",
        name = "assign_king",
        force_map_text = MapMode.Kingdoms,
        click_special_action = KingAssignationAction
      };
      AssetManager.powers.add(assignKing);
      return true;
    }

    private static bool KingAssignationAction(WorldTile pTile, string pPowerID) {
      Kingdom kingdom = pTile.zone.city?.kingdom;
      if (kingdom == null) {
        return false;
      }
      MapBox.instance.getObjectsInChunks(pTile, 3, MapObjectType.Actor);
      Actor newKing = MapBox.instance.temp_map_objects.FirstOrDefault(actor => actor.base_data.alive && actor.kingdom.isCiv() && actor.kingdom == kingdom)?.a;
      if (newKing == null) {
        return false;
      }
      if (kingdom.king != null) {
        kingdom.king.setProfession(UnitProfession.Unit);
      }
      kingdom.setKing(newKing);
      newKing.startShake();
      newKing.startColorEffect();
      return true;
    }
  }
}
