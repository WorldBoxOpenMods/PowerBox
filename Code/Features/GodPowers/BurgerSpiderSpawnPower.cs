using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class BurgerSpiderSpawnPower : AssetFeature<GodPower> {
    internal override FeatureRequirementList RequiredFeatures => typeof(Actors.BurgerSpider);
    protected override GodPower InitObject() {
      return new GodPower {
        id = "spawnBurgerSpider",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        name = "spawnBurgerSpider",
        spawnSound = "spawnAnt",
        actor_asset_id = "burgerSpider",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}
