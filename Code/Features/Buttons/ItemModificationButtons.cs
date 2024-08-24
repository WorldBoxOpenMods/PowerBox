using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.Features.Windows;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class ItemModificationButtons : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures + typeof(ItemAdditionPower) + typeof(ItemRemovalPower) + typeof(EditItemsWindow);
    internal override FeatureRequirementList OptionalFeatures => typeof(MushAnimalSpawnButton);
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
      GetFeature<EditItemsWindow>().InitEditItems(GetFeature<EditItemsWindow>().Object, null, type);
      GetFeature<EditItemsWindow>().Object.clickShow();
    }
  }
}
