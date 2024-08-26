using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class TumorAnimalSpawnPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_spawn_tumor_animal",
        name = "powerbox_spawn_tumor_animal",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        spawnSound = "Tumor_Spawn01",
        actor_asset_id = "tumor_monster_animal",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}
