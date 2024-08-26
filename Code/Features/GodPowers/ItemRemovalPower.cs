using System;
using System.Collections.Generic;
using PowerBox.Code.Features.Drops;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class ItemRemovalPower : AssetFeature<GodPower> {
    internal override FeatureRequirementList RequiredFeatures => new List<Type> { typeof(CommonItemDrop) };
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_remove_items",
        holdAction = true,
        showToolSizes = true,
        unselectWhenWindow = true,
        name = "powerbox_remove_items",
        dropID = GetFeature<CommonItemDrop>().Object.id,
        fallingChance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPower(pTile, pPower)
      };
    }
  }
}
