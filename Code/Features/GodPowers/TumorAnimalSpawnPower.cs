using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class TumorAnimalSpawnPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_spawn_tumor_animal",
        name = "powerbox_spawn_tumor_animal",
        rank = PowerRank.Rank0_free,
        unselect_when_window = true,
        show_spawn_effect = true,
        actor_spawn_height = 3f,
        sound_event = "Tumor_Spawn01",
        actor_asset_id = "tumor_monster_animal",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}
