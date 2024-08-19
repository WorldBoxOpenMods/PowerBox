using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.Features.Windows;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class ItemModificationButtons : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(ItemAdditionPower), typeof(ItemRemovalPower), typeof(EditItemsWindow) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(UnitSpawnButtons) };
    internal override bool Init() {
      Tab.CreateClickButton(
        "addItems",
        Resources.Load<Sprite>("powers/items_plus"),
        Tab.PowerboxTabObject.transform,
        AddItemsButtonClick
      );
      Tab.CreateClickButton(
        "removeItems",
        Resources.Load<Sprite>("powers/items_minus"),
        Tab.PowerboxTabObject.transform,
        RemoveItemsButtonCLick
      );
      return true;
    }
    private void AddItemsButtonClick() {
      ItemsButtonClick(PowerType.Add);
    }
    private void RemoveItemsButtonCLick() {
      ItemsButtonClick(PowerType.Remove);
    }
    private void ItemsButtonClick(PowerType type) {
      if (ScrollWindow.allWindows.TryGetValue("edit_items", out ScrollWindow editItemsWindow)) {
        GetFeature<EditItemsWindow>().InitEditItems(editItemsWindow, null, type);
        editItemsWindow.clickShow();
      }
    }
  }
}