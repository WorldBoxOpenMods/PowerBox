using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;

namespace PowerBox.Code.Features.GodPowers {
  public class TransportBoatSpawnPower : AssetFeature<GodPower> {
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
        showSpawnEffect = true,
        showToolSizes = false,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        actor_asset_id = "boat_transport",
        dropID = spawnTransportBoatDrop.id,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
    }
  }
}
