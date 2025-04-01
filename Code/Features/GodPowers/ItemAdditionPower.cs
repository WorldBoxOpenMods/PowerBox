using System;
using System.Collections.Generic;
using PowerBox.Code.Features.Drops;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class ItemAdditionPower : AssetFeature<GodPower> {
    internal override FeatureRequirementList RequiredFeatures => new List<Type> { typeof(CommonItemDrop) };
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_add_items",
        hold_action = true,
        show_tool_sizes = true,
        unselect_when_window = true,
        name = "powerbox_add_items",
        drop_id = GetFeature<CommonItemDrop>().Object.id,
        falling_chance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPowerForDropsFull(pTile, pPower)
      };
    }
  }
}
