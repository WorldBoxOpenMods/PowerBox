using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class MushCreatureSpawnPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_spawn_mush_creature",
        name = "powerbox_spawn_mush_creature",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        spawnSound = "spawnZombie",
        actor_asset_id = "mush_unit",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}
