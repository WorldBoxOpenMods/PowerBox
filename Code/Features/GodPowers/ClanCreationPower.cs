using System.Linq;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class ClanCreationPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower() {
        id = "powerbox_create_clan",
        name = "powerbox_create_clan",
        click_special_action = ClanCreationAction
      };
    }
    private static bool ClanCreationAction(WorldTile pTile, string pPowerId) {
      Actor newClanLeader = Finder.getUnitsFromChunk(pTile, 3).FirstOrDefault(actor => actor.isAlive() && actor.kingdom.isCiv())?.a;
      if (newClanLeader == null) {
        return false;
      }
      if (newClanLeader.hasClan()) {
        newClanLeader.clan.units.Remove(newClanLeader);
      }
      World.world.clans.newClan(newClanLeader);
      newClanLeader.startShake();
      newClanLeader.startColorEffect();
      return true;
    }
  }
}
