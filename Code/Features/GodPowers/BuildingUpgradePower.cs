using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class BuildingUpgradePower : Feature {
    internal override bool Init() {
      GodPower upgradeBuildingAdd = new GodPower {
        id = "upgradeBuildingAdd",
        holdAction = true,
        showToolSizes = true,
        unselectWhenWindow = true,
        name = "upgradeBuildingAdd",
        dropID = "upgradeBuildingAdd",
        fallingChance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPower(pTile, pPower)
      };
      AssetManager.powers.add(upgradeBuildingAdd);

      DropAsset upgradeBuildingAddDrop = new DropAsset {
        id = "upgradeBuildingAdd",
        path_texture = "drops/drop_snow",
        animated = true,
        animation_speed = 0.03f,
        default_scale = 0.1f,
        action_landed = BuildingUpgradeAction
      };
      AssetManager.drops.add(upgradeBuildingAddDrop);

      return true;
    }
    
    private static void BuildingUpgradeAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile?.building != null && !string.IsNullOrWhiteSpace(pTile.building.asset.upgradeTo)) {
        BuildingAsset pTemplate = AssetManager.buildings.get(pTile.building.asset.upgradeTo);
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