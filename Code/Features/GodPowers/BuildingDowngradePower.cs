using System.Linq;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class BuildingDowngradePower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset downgradeBuildingAddDrop = new DropAsset {
        id = "downgradeBuildingAdd",
        path_texture = "drops/drop_snow",
        animated = true,
        animation_speed = 0.03f,
        default_scale = 0.1f,
        action_landed = BuildingDowngradeAction
      };
      AssetManager.drops.add(downgradeBuildingAddDrop);
      
      GodPower downgradeBuildingAdd = new GodPower {
        id = downgradeBuildingAddDrop.id,
        holdAction = true,
        showToolSizes = true,
        unselectWhenWindow = true,
        name = downgradeBuildingAddDrop.id,
        dropID = downgradeBuildingAddDrop.id,
        fallingChance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPower(pTile, pPower)
      };

      return downgradeBuildingAdd;
    }
    
    private static void BuildingDowngradeAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile?.building != null) {
        BuildingAsset pTemplate = AssetManager.buildings.list.FirstOrDefault(asset => asset.upgradeTo == pTile.building.asset.id);
        if (pTemplate != null) {
          pTile.building.city?.setBuildingDictID(pTile.building, false);
          pTile.building.setTemplate(pTemplate);
          pTile.building.city?.setBuildingDictID(pTile.building, true);
          pTile.building.initAnimationData();
          pTile.building.updateStats();
          pTile.building.data.health = pTile.building.getMaxHealth();
          pTile.building.fillTiles();
        }
      }
    }
  }
}
