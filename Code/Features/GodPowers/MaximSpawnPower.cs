using NeoModLoader.api;
using NeoModLoader.api.features;
using PowerBox.Code.Features.Actors;

namespace PowerBox.Code.Features.GodPowers {
  public class MaximSpawnPower : ModAssetFeature<GodPower> {
    public override ModFeatureRequirementList RequiredModFeatures => typeof(Maxim);
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_spawn_maxim",
        rank = PowerRank.Rank0_free,
        unselect_when_window = true,
        show_spawn_effect = true,
        actor_spawn_height = 3f,
        name = "powerbox_spawn_maxim",
        sound_event = "spawnHuman",
        actor_asset_id = GetFeature<Maxim>().Object.id,
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
    }
  }
}
