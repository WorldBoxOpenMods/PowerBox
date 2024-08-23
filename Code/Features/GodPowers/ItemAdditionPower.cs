using System;
using System.Collections.Generic;
using PowerBox.Code.Features.Drops;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class ItemAdditionPower : Feature {
    internal override FeatureRequirementList RequiredFeatures => new List<Type> { typeof(CommonItemDrop) };

    internal override bool Init() {
      GodPower addItems = new GodPower {
        id = "addItems",
        holdAction = true,
        showToolSizes = true,
        unselectWhenWindow = true,
        name = "addItems",
        dropID = "change_items",
        fallingChance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPower(pTile, pPower)
      };
      AssetManager.powers.add(addItems);
      return true;
    }
  }
}