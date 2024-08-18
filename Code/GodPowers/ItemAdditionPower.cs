using System;
using System.Collections.Generic;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.GodPowers {
  public class ItemAdditionPower : Feature {
    internal override List<Type> RequiredFeatures => new List<Type> { typeof(Drops.CommonItemDrop) };

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