using System.Linq;
using NeoModLoader.api.features;
using PowerBox.Code.Utils;

namespace PowerBox.Code.Features.GodPowers {
  public class NonRandomFriendshipPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower() {
        id = "powerbox_non_random_friendship",
        name = "powerbox_non_random_friendship",
        force_map_mode = MetaType.Kingdom,
        select_button_action = _ => !WhisperUtils.TryResetWhisperKingdoms(),
        click_special_action = NonRandomFriendshipAction
      };
    }
    
    private static bool NonRandomFriendshipAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile?.zone.city == null)
        return false;

      Kingdom kingdom = pTile.zone.city.kingdom;
      
      if (Config.whisper_A == null) {
        Config.whisper_A = kingdom;
        return false;
      }
      if (Config.whisper_A.id == kingdom.id) {
        return false;
      }
      if (!Config.whisper_A.isAlive()) {
        Config.whisper_A = kingdom;
        return false;
      }
      Config.whisper_B = kingdom;
      World.world.wars.list.Where(w => w.isInWarWith(Config.whisper_A, Config.whisper_B)).ToList().ForEach(w => World.world.wars.endWar(w));
      Config.whisper_A = null;
      Config.whisper_B = null;
      return true;
    }
  }
}
