using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class AssignKingPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      GodPower assignKing = new GodPower() {
        id = "powerbox_assign_king",
        name = "powerbox_assign_king",
        force_map_mode = MetaType.Kingdom,
        click_special_action = KingAssignationAction
      };
      return assignKing;
    }

    private static bool KingAssignationAction(WorldTile pTile, string pPowerID) {
      Kingdom kingdom = pTile.zone.city?.kingdom;
      if (kingdom == null) {
        return false;
      }
      Actor newKing = Finder.getUnitsFromChunk(pTile, 3).FirstOrDefault(actor => actor.isAlive() && actor.kingdom.isCiv() && actor.kingdom == kingdom)?.a;
      if (newKing == null) {
        return false;
      }
      if (newKing.isCityLeader()) {
        newKing.city.removeLeader();
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
