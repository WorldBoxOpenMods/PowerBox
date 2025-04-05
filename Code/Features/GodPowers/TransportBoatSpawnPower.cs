using NeoModLoader.api.features;
using PowerBox.Code.Utils;

namespace PowerBox.Code.Features.GodPowers {
  public class TransportBoatSpawnPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset spawnTransportBoatDrop = new DropAsset {
        id = "powerbox_spawn_boat_transport",
        path_texture = "drops/drop_metal",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = (pTile, pDropID) => BoatUtils.BoatSpawnAction(pTile, "boat_transport"),
        material = "mat_world_object_lit",
        sound_drop = "event:/SFX/DROPS/DropRainGamma"
      };
      AssetManager.drops.add(spawnTransportBoatDrop);
      
      return new GodPower {
        id = spawnTransportBoatDrop.id,
        name = spawnTransportBoatDrop.id,
        show_spawn_effect = true,
        show_tool_sizes = false,
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = true,
        unselect_when_window = true,
        actor_asset_id = "boat_transport",
        drop_id = spawnTransportBoatDrop.id,
        cached_drop_asset = spawnTransportBoatDrop,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
    }
  }
}
