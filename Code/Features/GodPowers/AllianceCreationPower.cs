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
        force_map_text = MapMode.Kingdoms,
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
      if (Config.whisperA == null) {
        Config.whisperA = kingdom;
        return false;
      }

      if (Config.whisperB == null && Config.whisperA == kingdom) {
        WorldTip.showNow("powerbox_create_alliance_same_kingdom_selected_twice_error", true, "top");
        return false;
      }

      if (Config.whisperB == null) {
        Config.whisperB = kingdom;
      }

      if (Config.whisperB != Config.whisperA) {

        if (Alliance.isSame(Config.whisperA.getAlliance(), Config.whisperB.getAlliance())) {
          WorldTip.showNow("powerbox_create_alliance_already_allied_error", true, "top");
          Config.whisperB = null;
          return false;
        }

        foreach (War war in World.world.wars.getWars(Config.whisperA).Where(war => war.isInWarWith(Config.whisperA, Config.whisperB))) {
          war.removeFromWar(Config.whisperA);
          war.removeFromWar(Config.whisperB);
        }

        Alliance allianceA = Config.whisperA.getAlliance();
        Alliance allianceB = Config.whisperB.getAlliance();
        if (allianceA != null) {
          if (allianceB != null) {
            IEnumerable<Kingdom> kingdoms = allianceB.kingdoms_list;
            World.world.alliances.dissolveAlliance(allianceB);
            foreach (Kingdom ally in kingdoms) {
              ForceIntoAlliance(allianceA, ally);
            }
          } else {
            ForceIntoAlliance(allianceA, Config.whisperB);
          }
        } else {
          if (allianceB == null) {
            ForceNewAlliance(Config.whisperA, Config.whisperB);
          } else {
            ForceIntoAlliance(allianceB, Config.whisperA);
          }
        }
        WorldTip.showNow("powerbox_create_alliance_success", true, "top");
        Config.whisperA = null;
        Config.whisperB = null;
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
      alliance.createAlliance();
      alliance.data.founder_kingdom_1 = kingdomA.data.name;
      if (kingdomA.king != null) {
        alliance.data.founder_name_1 = kingdomA.king.getName();
      }
      ForceIntoAlliance(alliance, kingdomA);
      ForceIntoAlliance(alliance, kingdomB);
      WorldLog.logAllianceCreated(alliance);
    }

  }
}
