using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class GregSpawnPower : AssetFeature<GodPower> {

    protected override GodPower InitObject() {
      return new GodPower {
        id = "spawnGregCreature",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        name = "spawnGregCreature",
        spawnSound = "spawnHuman",
        actor_asset_id = "greg",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}
