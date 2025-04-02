using System.Linq;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class BuildingDowngradePower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset downgradeBuildingAddDrop = new DropAsset {
        id = "powerbox_downgrade_building",
        path_texture = "drops/drop_snow",
        animated = true,
        animation_speed = 0.03f,
        default_scale = 0.1f,
        action_landed = BuildingDowngradeAction
      };
      AssetManager.drops.add(downgradeBuildingAddDrop);
      
      GodPower downgradeBuildingAdd = new GodPower {
        id = downgradeBuildingAddDrop.id,
        hold_action = true,
        show_tool_sizes = true,
        unselect_when_window = true,
        name = downgradeBuildingAddDrop.id,
        drop_id = downgradeBuildingAddDrop.id,
        falling_chance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPowerForDropsFull(pTile, pPower)
      };

      return downgradeBuildingAdd;
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
