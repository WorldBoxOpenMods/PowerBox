using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class MushAnimalSpawnPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_spawn_mush_animal",
        name = "powerbox_spawn_mush_animal",
        rank = PowerRank.Rank0_free,
        unselect_when_window = true,
        show_spawn_effect = true,
        actor_spawn_height = 3f,
        sound_event = "spawnZombie",
        actor_asset_id = "mush_animal",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}
