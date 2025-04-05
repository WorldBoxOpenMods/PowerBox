using NeoModLoader.api.features;
using PowerBox.Code.Utils;

namespace PowerBox.Code.Features.GodPowers {
  public class FishingBoatSpawnPower : ModAssetFeature<GodPower> {
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
        show_spawn_effect = true,
        show_tool_sizes = false,
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = true,
        unselect_when_window = true,
        actor_asset_id = "boat_fishing",
        drop_id = spawnFishingBoatDrop.id,
        cached_drop_asset = spawnFishingBoatDrop,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };

      return spawnFishingBoat;
    }
  }
}
