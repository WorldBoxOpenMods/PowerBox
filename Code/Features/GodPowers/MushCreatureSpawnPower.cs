using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class MushCreatureSpawnPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_spawn_mush_creature",
        name = "powerbox_spawn_mush_creature",
        rank = PowerRank.Rank0_free,
        unselect_when_window = true,
        show_spawn_effect = true,
        actor_spawn_height = 3f,
        sound_event = "spawnZombie",
        actor_asset_id = "mush_unit",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}
