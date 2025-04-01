using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;

namespace PowerBox.Code.Features.GodPowers {
  public class AllianceCreationPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      GodPower createAlliance = new GodPower() {
        id = "powerbox_create_alliance",
        name = "powerbox_create_alliance",
        force_map_mode = MetaType.Kingdom,
        select_button_action = _ => !WhisperUtils.TryResetWhisperKingdoms(),
        click_special_action = AllianceCreationAction
      };
      return createAlliance;
    }
    
    private static bool AllianceCreationAction(WorldTile pTile, string pPowerID) {
      City city = pTile.zone.city;
      if (city == null) {
        return false;
      }

      Kingdom kingdom = city.kingdom;
      if (Config.whisper_A == null) {
        Config.whisper_A = kingdom;
        return false;
      }

      if (Config.whisper_B == null && Config.whisper_A == kingdom) {
        WorldTip.showNow("powerbox_create_alliance_same_kingdom_selected_twice_error", true, "top");
        return false;
      }

      if (Config.whisper_B == null) {
        Config.whisper_B = kingdom;
      }

      if (Config.whisper_B != Config.whisper_A) {

        if (Alliance.isSame(Config.whisper_A.getAlliance(), Config.whisper_B.getAlliance())) {
          WorldTip.showNow("powerbox_create_alliance_already_allied_error", true, "top");
          Config.whisper_B = null;
          return false;
        }

        foreach (War war in World.world.wars.getWars(Config.whisper_A).Where(war => war.isInWarWith(Config.whisper_A, Config.whisper_B))) {
          war.removeFromWar(Config.whisper_A, true);
          war.removeFromWar(Config.whisper_B, true);
        }

        Alliance allianceA = Config.whisper_A.getAlliance();
        Alliance allianceB = Config.whisper_B.getAlliance();
        if (allianceA != null) {
          if (allianceB != null) {
            IEnumerable<Kingdom> kingdoms = allianceB.kingdoms_list;
            World.world.alliances.dissolveAlliance(allianceB);
            foreach (Kingdom ally in kingdoms) {
              ForceIntoAlliance(allianceA, ally);
            }
          } else {
            ForceIntoAlliance(allianceA, Config.whisper_B);
          }
        } else {
          if (allianceB == null) {
            ForceNewAlliance(Config.whisper_A, Config.whisper_B);
          } else {
            ForceIntoAlliance(allianceB, Config.whisper_A);
          }
        }
        WorldTip.showNow("powerbox_create_alliance_success", true, "top");
        Config.whisper_A = null;
        Config.whisper_B = null;
      }

      return true;
    }

    private static void ForceIntoAlliance(Alliance alliance, Kingdom kingdom) {
      alliance.kingdoms_hashset.Add(kingdom);
      kingdom.allianceJoin(alliance);
      alliance.recalculate();
      alliance.data.timestamp_member_joined = World.world.getCurWorldTime();
    }

    private static void ForceNewAlliance(Kingdom kingdomA, Kingdom kingdomB) {
      Alliance alliance = World.world.alliances.newObject();
      alliance.createNewAlliance();
      alliance.data.founder_kingdom_id = kingdomA.data.id;
      alliance.data.founder_kingdom_name = kingdomB.data.name;
      if (kingdomA.king != null) {
        alliance.data.founder_actor_id = kingdomA.king.data.id;
        alliance.data.founder_actor_name = kingdomA.king.getName();
      }
      ForceIntoAlliance(alliance, kingdomA);
      ForceIntoAlliance(alliance, kingdomB);
      WorldLog.logAllianceCreated(alliance);
    }

  }
}
