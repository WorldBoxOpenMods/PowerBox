using System.Linq;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class AssignLeaderPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      GodPower assignLeader = new GodPower() {
        id = "powerbox_assign_leader",
        name = "powerbox_assign_leader",
        force_map_text = MapMode.Cities,
        click_special_action = LeaderAssignationAction
      };
      return assignLeader;
    }

    private static bool LeaderAssignationAction(WorldTile pTile, string pPowerID) {
      City city = pTile.zone.city;
      if (city == null) {
        return false;
      }
      MapBox.instance.getObjectsInChunks(pTile, 3, MapObjectType.Actor);
      Actor newLeader = MapBox.instance.temp_map_objects.FirstOrDefault(actor => actor.base_data.alive && actor.kingdom.isCiv() && actor.city == city)?.a;
      if (newLeader == null) {
        return false;
      }
      if (newLeader.isKing()) {
        newLeader.setProfession(UnitProfession.Unit);
        newLeader.kingdom.king = null;
        newLeader.kingdom.data.kingID = null;
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
