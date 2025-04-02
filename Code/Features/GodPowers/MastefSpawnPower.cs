using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class MastefSpawnPower : ModAssetFeature<GodPower> {
    public override ModFeatureRequirementList RequiredModFeatures => typeof(Actors.Mastef);
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_spawn_mastef",
        rank = PowerRank.Rank0_free,
        unselect_when_window = true,
        show_spawn_effect = true,
        actor_spawn_height = 3f,
        name = "powerbox_spawn_mastef",
        sound_event = "spawnHuman",
        actor_asset_id = GetFeature<Actors.Mastef>().Object.id,
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}
