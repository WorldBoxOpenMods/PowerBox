using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;

namespace PowerBox.Code.GodPowers {
  public class FishingBoatSpawnPower : Feature {
    internal override bool Init() {
      GodPower spawnFishingBoat = new GodPower {
        id = "spawn_boat_fishing",
        name = "spawn_boat_fishing",
        showSpawnEffect = true,
        showToolSizes = false,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        actor_asset_id = "boat_fishing",
        dropID = "spawn_boat_fishing",
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      AssetManager.powers.add(spawnFishingBoat);

      DropAsset spawnFishingBoatDrop = new DropAsset {
        id = "spawn_boat_fishing",
        path_texture = "drops/drop_metal",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = (pTile, pDropID) => BoatUtils.BoatSpawnAction(pTile, "boat_fishing"),
        material = "mat_world_object_lit",
        sound_drop = "event:/SFX/DROPS/DropRainGamma"
      };
      AssetManager.drops.add(spawnFishingBoatDrop);
      return true;
    }
  }
}