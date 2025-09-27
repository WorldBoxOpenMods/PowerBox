using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class AssignLeaderPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      GodPower assignLeader = new GodPower {
        id = "powerbox_assign_leader",
        name = "powerbox_assign_leader",
        force_map_mode = MetaType.City,
        click_special_action = LeaderAssignationAction
      };
      return assignLeader;
    }

    private static bool LeaderAssignationAction(WorldTile pTile, string pPowerID) {
      City city = pTile.zone.city;
      if (city == null) {
        return false;
      }
      Actor newLeader = Finder.getUnitsFromChunk(pTile, 1, 2).FirstOrDefault(actor => actor.isAlive() && actor.kingdom.isCiv() && actor.city == city);
      if (newLeader == null) {
        return false;
      }
      if (newLeader.isKing()) {
        newLeader.setProfession(UnitProfession.Unit);
        newLeader.kingdom.king = null;
        newLeader.kingdom.data.kingID = -1;
      }
      city.removeLeader();
      city.leader = newLeader;
      city.data.leaderID = newLeader.data.id;
      newLeader.startShake();
      newLeader.startColorEffect();
      return true;
    }
  }
}
