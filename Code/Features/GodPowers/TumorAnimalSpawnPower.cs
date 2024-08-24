using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class TumorAnimalSpawnPower : AssetFeature<GodPower> {

    protected override GodPower InitObject() {
      return new GodPower {
        id = "spawnTumorCreatureAnimal",
        name = "spawnTumorCreatureAnimal",
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
