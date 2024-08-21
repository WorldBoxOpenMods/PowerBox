using System.Linq;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class AssignLeaderPower : Feature {
    internal override bool Init() {
      GodPower assignLeader = new GodPower() {
        id = "assign_leader",
        name = "assign_leader",
        force_map_text = MapMode.Cities,
        click_special_action = LeaderAssignationAction
      };
      AssetManager.powers.add(assignLeader);
      return true;
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
      city.removeLeader();
      city.leader = newLeader;
      city.data.leaderID = newLeader.data.id;
      newLeader.startShake();
      newLeader.startColorEffect();
      return true;
    }
  }
}