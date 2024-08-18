using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;

namespace PowerBox.Code.GodPowers {
  public class TransportBoatSpawnPower : Feature {
    internal override bool Init() {
      GodPower spawnTransportBoat = new GodPower {
        id = "spawn_boat_transport",
        name = "spawn_boat_transport",
        showSpawnEffect = true,
        showToolSizes = false,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        actor_asset_id = "boat_transport",
        dropID = "spawn_boat_transport",
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      AssetManager.powers.add(spawnTransportBoat);

      DropAsset spawnTransportBoatDrop = new DropAsset {
        id = "spawn_boat_transport",
        path_texture = "drops/drop_metal",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = (pTile, pDropID) => BoatUtils.BoatSpawnAction(pTile, "boat_transport"),
        material = "mat_world_object_lit",
        sound_drop = "event:/SFX/DROPS/DropRainGamma"
      };
      AssetManager.drops.add(spawnTransportBoatDrop);
      return true;
    }
  }
}