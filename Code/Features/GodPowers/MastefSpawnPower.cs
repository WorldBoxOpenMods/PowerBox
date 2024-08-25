using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class MastefSpawnPower : AssetFeature<GodPower> {
    internal override FeatureRequirementList RequiredFeatures => typeof(Actors.Mastef);
    protected override GodPower InitObject() {
      return new GodPower {
        id = "spawnMastefCreature",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        name = "spawnMastefCreature",
        spawnSound = "spawnHuman",
        actor_asset_id = GetFeature<Actors.Mastef>().Object.id,
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}