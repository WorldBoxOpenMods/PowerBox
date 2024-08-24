using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class BuildingUpgradePower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset upgradeBuildingAddDrop = new DropAsset {
        id = "upgradeBuildingAdd",
        path_texture = "drops/drop_snow",
        animated = true,
        animation_speed = 0.03f,
        default_scale = 0.1f,
        action_landed = BuildingUpgradeAction
      };
      AssetManager.drops.add(upgradeBuildingAddDrop);

      GodPower upgradeBuildingAdd = new GodPower {
        id = upgradeBuildingAddDrop.id,
        holdAction = true,
        showToolSizes = true,
        unselectWhenWindow = true,
        name = upgradeBuildingAddDrop.id,
        dropID = upgradeBuildingAddDrop.id,
        fallingChance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPower(pTile, pPower)
      };

      return upgradeBuildingAdd;
    }
    
    private static void BuildingUpgradeAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile?.building != null && pTile.building.canBeUpgraded() && !string.IsNullOrWhiteSpace(pTile.building.asset.upgradeTo)) {
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
