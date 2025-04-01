using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class GregSpawnPower : AssetFeature<GodPower> {

    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_spawn_greg",
        rank = PowerRank.Rank0_free,
        unselect_when_window = true,
        show_spawn_effect = true,
        actor_spawn_height = 3f,
        name = "powerbox_spawn_greg",
        sound_event = "spawnHuman",
        actor_asset_id = "greg",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}
