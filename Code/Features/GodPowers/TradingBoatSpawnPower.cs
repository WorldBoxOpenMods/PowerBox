using NeoModLoader.api;
using NeoModLoader.api.features;
using PowerBox.Code.Utils;

namespace PowerBox.Code.Features.GodPowers {
  public class TradingBoatSpawnPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset spawnTradingBoatDrop = new DropAsset {
        id = "powerbox_spawn_boat_trading",
        path_texture = "drops/drop_metal",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = (pTile, pDropID) => BoatUtils.BoatSpawnAction(pTile, "boat_trading"),
        material = "mat_world_object_lit",
        sound_drop = "event:/SFX/DROPS/DropRainGamma"
      };
      AssetManager.drops.add(spawnTradingBoatDrop);
      
      GodPower spawnTradingBoat = new GodPower {
        id = spawnTradingBoatDrop.id,
        name = spawnTradingBoatDrop.id,
        show_spawn_effect = true,
        show_tool_sizes = false,
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = true,
        unselect_when_window = true,
        actor_asset_id = "boat_trading",
        drop_id = spawnTradingBoatDrop.id,
        cached_drop_asset = spawnTradingBoatDrop,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      
      return spawnTradingBoat;
    }
  }
}
