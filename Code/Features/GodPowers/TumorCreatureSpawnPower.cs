using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class TumorCreatureSpawnPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_spawn_tumor_creature",
        name = "powerbox_spawn_tumor_creature",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        spawnSound = "Tumor_Spawn01",
        actor_asset_id = "tumor_monster_unit",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}
