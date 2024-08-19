using System;
using System.Collections.Generic;
using PowerBox.Code.Features.Drops;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class ItemRemovalPower : Feature {
    internal override List<Type> RequiredFeatures => new List<Type> { typeof(CommonItemDrop) };
    internal override bool Init() {
      GodPower removeItems = new GodPower {
        id = "removeItems",
        holdAction = true,
        showToolSizes = true,
        unselectWhenWindow = true,
        name = "removeItems",
        dropID = "change_items",
        fallingChance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPower(pTile, pPower)
      };
      AssetManager.powers.add(removeItems);
      return true;
    }
  }
}