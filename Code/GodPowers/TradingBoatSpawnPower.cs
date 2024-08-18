using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;

namespace PowerBox.Code.GodPowers {
  public class TradingBoatSpawnPower : Feature {
    internal override bool Init() {
      GodPower spawnTradingBoat = new GodPower {
        id = "spawn_boat_trading",
        name = "spawn_boat_trading",
        showSpawnEffect = true,
        showToolSizes = false,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        actor_asset_id = "boat_trading",
        dropID = "spawn_boat_trading",
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      AssetManager.powers.add(spawnTradingBoat);

      DropAsset spawnTradingBoatDrop = new DropAsset {
        id = "spawn_boat_trading",
        path_texture = "drops/drop_metal",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = (pTile, pDropID) => BoatUtils.BoatSpawnAction(pTile, "boat_trading"),
        material = "mat_world_object_lit",
        sound_drop = "event:/SFX/DROPS/DropRainGamma"
      };
      AssetManager.drops.add(spawnTradingBoatDrop);
      return true;
    }
  }
}