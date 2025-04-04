using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class BuildingUpgradePower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset upgradeBuildingDrop = new DropAsset {
        id = "powerbox_upgrade_building",
        path_texture = "drops/drop_snow",
        animated = true,
        animation_speed = 0.03f,
        default_scale = 0.1f,
        material = "mat_world_object_lit",
        type = DropType.DropMagic,
        action_landed = BuildingUpgradeAction
      };
      AssetManager.drops.add(upgradeBuildingDrop);

      GodPower upgradeBuilding = new GodPower {
        id = upgradeBuildingDrop.id,
        hold_action = true,
        show_tool_sizes = true,
        unselect_when_window = true,
        name = upgradeBuildingDrop.id,
        drop_id = upgradeBuildingDrop.id,
        cached_drop_asset = upgradeBuildingDrop,
        falling_chance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPowerForDropsFull(pTile, pPower)
      };

      return upgradeBuilding;
    }
    
    private static void BuildingUpgradeAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile?.building != null && pTile.building.canBeUpgraded() && !string.IsNullOrWhiteSpace(pTile.building.asset.upgrade_to)) {
        BuildingAsset pTemplate = AssetManager.buildings.get(pTile.building.asset.upgrade_to);
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
