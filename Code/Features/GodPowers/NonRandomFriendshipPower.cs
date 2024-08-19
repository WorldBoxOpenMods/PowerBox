using System.Linq;
using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;

namespace PowerBox.Code.Features.GodPowers {
  public class NonRandomFriendshipPower : Feature {
    internal override bool Init() {
      GodPower friendshipNotRandom = new GodPower() {
        id = "friendshipNR",
        name = "friendshipNR",
        force_map_text = MapMode.Kingdoms,
        select_button_action = _ => !WhisperUtils.TryResetWhisperKingdoms(),
        click_special_action = NonRandomFriendshipAction
      };
      AssetManager.powers.add(friendshipNotRandom);
      return true;
    }
    
    private static bool NonRandomFriendshipAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile?.zone.city == null)
        return false;

      Kingdom kingdom = pTile.zone.city.kingdom;
      
      if (Config.whisperA == null) {
        Config.whisperA = kingdom;
        return false;
      }
      if (Config.whisperA.id == kingdom.id) {
        return false;
      }
      if (!Config.whisperA.isAlive()) {
        Config.whisperA = kingdom;
        return false;
      }
      Config.whisperB = kingdom;
      World.world.wars.list.Where(w => w.isInWarWith(Config.whisperA, Config.whisperB)).ToList().ForEach(w => World.world.wars.endWar(w));
      Config.whisperA = null;
      Config.whisperB = null;
      return true;
    }
  }
}