using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;

namespace PowerBox.Code.Features.GodPowers {
  public class FishingBoatSpawnPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset spawnFishingBoatDrop = new DropAsset {
        id = "powerbox_spawn_boat_fishing",
        path_texture = "drops/drop_metal",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = (pTile, pDropID) => BoatUtils.BoatSpawnAction(pTile, "boat_fishing"),
        material = "mat_world_object_lit",
        sound_drop = "event:/SFX/DROPS/DropRainGamma"
      };
      AssetManager.drops.add(spawnFishingBoatDrop);
      
      GodPower spawnFishingBoat = new GodPower {
        id = spawnFishingBoatDrop.id,
        name = spawnFishingBoatDrop.id,
        showSpawnEffect = true,
        showToolSizes = false,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        actor_asset_id = "boat_fishing",
        dropID = spawnFishingBoatDrop.id,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };

      return spawnFishingBoat;
    }
  }
}
