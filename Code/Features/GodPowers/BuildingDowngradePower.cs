using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class BuildingDowngradePower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset downgradeBuildingDrop = new DropAsset {
        id = "powerbox_downgrade_building",
        path_texture = "drops/drop_snow",
        animated = true,
        animation_speed = 0.03f,
        default_scale = 0.1f,
        material = "mat_world_object_lit",
        type = DropType.DropMagic,
        action_landed = BuildingDowngradeAction
      };
      AssetManager.drops.add(downgradeBuildingDrop);

      GodPower downgradeBuilding = new GodPower {
        id = downgradeBuildingDrop.id,
        hold_action = true,
        show_tool_sizes = true,
        unselect_when_window = true,
        name = downgradeBuildingDrop.id,
        drop_id = downgradeBuildingDrop.id,
        cached_drop_asset = downgradeBuildingDrop,
        falling_chance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPowerForDropsFull(pTile, pPower)
      };

      return downgradeBuilding;
    }

    private static void BuildingDowngradeAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile?.building != null) {
        BuildingAsset pTemplate = AssetManager.buildings.list.FirstOrDefault(asset => asset.upgrade_to == pTile.building.asset.id);
        if (pTemplate != null) {
          pTile.building.city?.setBuildingDictID(pTile.building);
          pTile.building.setTemplate(pTemplate);
          pTile.building.initAnimationData();
          pTile.building.updateStats();
          pTile.building.data.health = pTile.building.getMaxHealth();
          pTile.building.fillTiles();
        }
      }
    }
  }
}
