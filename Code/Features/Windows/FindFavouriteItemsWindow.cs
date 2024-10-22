using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HarmonyLib;
using NeoModLoader.General;
using PowerBox.Code.LoadingSystem;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Windows {
  public class FindFavouriteItemsWindow : WindowBase<FindFavouriteItemsWindow> {
    internal override FeatureRequirementList RequiredFeatures => new List<Type> {typeof(Buttons.Tab)};

    private static Thread _itemCacheCheckThread;
    private static readonly List<ItemData> FavoriteItems = new List<ItemData>();
    private static readonly Dictionary<ItemData, (Actor actor, City city)> ItemOwnerCache = new Dictionary<ItemData, (Actor actor, City city)>();
    protected override ScrollWindow InitObject() {
      ScrollWindow window = WindowCreator.CreateEmptyWindow("powerbox_find_favorite_items", "powerbox_find_favorite_items");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("powerbox_find_favorite_items");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;

      window.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);

      GameObject viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport");
      RectTransform viewportRect = viewport.GetComponent<RectTransform>();
      viewportRect.sizeDelta = new Vector2(0, 17);

      new Harmony("key.worldbox.powerbox").Patch(
        AccessTools.Method(typeof(EquipmentButton), nameof(EquipmentButton.Start)),
        new HarmonyMethod(AccessTools.Method(typeof(FindFavouriteItemsWindow), nameof(EquipmentButton_Start_Postfix)))
      );
      return window;
    }
    internal static void AddButtonToNotAttachTo(EquipmentButton button) {
      ButtonsToNotAttachTo.Add(button);
    }
    private static readonly List<EquipmentButton> ButtonsToNotAttachTo = new List<EquipmentButton>();
    // ReSharper disable once InconsistentNaming
    private static void EquipmentButton_Start_Postfix(EquipmentButton __instance) {
      if (ButtonsToNotAttachTo.Contains(__instance)) {
        ButtonsToNotAttachTo.Remove(__instance);
        return;
      }
      __instance.GetComponent<Button>().onClick.AddListener(() => ToggleFavoriteItem(__instance.item_data));
    }
    private static void ToggleFavoriteItem(ItemData itemData) {
      if (FavoriteItems.Contains(itemData)) {
        FavoriteItems.Remove(itemData);
        WorldTip.showNow("powerbox_item_unfavorited_message", true, "top");
      } else {
        FavoriteItems.Add(itemData);
        WorldTip.showNow("powerbox_item_favorited_message", true, "top");
      }
    }
    public void FindFavoriteItemsButtonClick() {
      InitFindFavouriteItems(Window);
      Window.clickShow();
    }
    private void CheckFavoriteItemsStatus() {
      bool itemGone = false;
      foreach (ItemData itemData in FavoriteItems.ToList()) {
        (Actor actor, City city) = GetItemOwner(itemData);
        if (actor is null && city is null) {
          if (FavoriteItems.Contains(itemData)) {
            FavoriteItems.Remove(itemData);
            itemGone = true;
          }
        }
      }
      if (itemGone) {
        InitFindFavouriteItems(Window);
      }
    }
    private static (Actor actor, City city) GetItemOwner(ItemData itemData) {
      lock (ItemOwnerCache) {
        if (ItemOwnerCache.TryGetValue(itemData, out (Actor actor, City city) owner)) {
          if (owner.actor != null) {
            if (owner.actor.equipment.getDataForSave().Contains(itemData)) {
              return owner;
            }
          } else if (owner.city?.data?.storage != null) {
            if (typeof(EquipmentType).GetEnumValues().Cast<EquipmentType>().Any(type => owner.city.getEquipmentList(type).Contains(itemData))) {
              return owner;
            }
          }
        }
        ItemOwnerCache.Remove(itemData);
        foreach (City city in World.world.cities.list.Where(c => c?.data?.storage != null).Where(city => typeof(EquipmentType).GetEnumValues().Cast<EquipmentType>().Any(type => city.getEquipmentList(type).Contains(itemData)))) {
          ItemOwnerCache.Add(itemData, (null, city));
          return (null, city);
        }
        foreach (Actor actor in World.world.units.getSimpleList().Where(unit => unit.equipment?.getDataForSave()?.Contains(itemData) ?? false)) {
          ItemOwnerCache.Add(itemData, (actor, null));
          return (actor, null);
        }
        return (null, null);
      }
    }
    private void InitFindFavouriteItems(ScrollWindow window) {
      RectTransform rt = SpriteHighlighter.GetComponent<RectTransform>();
      rt.sizeDelta = new Vector2(60f, 60f);

      GameObject content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/" + window.name + "/Background/Scroll View/Viewport/Content");
      for (int i = 0; i < content.transform.childCount; i++) {
        UnityEngine.Object.Destroy(content.transform.GetChild(i).gameObject);
      }
      window.resetScroll();
      ScrollWindow.allWindows.TryGetValue("inspect_unit", out ScrollWindow inspectUnit);
      if (inspectUnit is null) {
        return;
      }
      WindowCreatureInfo windowCreatureInfo = inspectUnit.GetComponent<WindowCreatureInfo>();
      EquipmentButton itemButtonPrefab = windowCreatureInfo.prefabEquipment;
      foreach (ItemData itemData in FavoriteItems) {
        EquipmentButton itemButton = LoadItemButton(itemData, itemButtonPrefab, content.transform, (button) => {
          (Actor actor, City city) owner = GetItemOwner(itemData);
          if (owner.actor != null) {
            Config.selectedUnit = owner.actor;
            ScrollWindow.showWindow("inspect_unit");
          } else if (owner.city != null) {
            Config.selectedCity = owner.city;
            ScrollWindow.showWindow("village");
          } else if (FavoriteItems.Contains(itemData)) {
            WorldTip.showNow("powerbox_item_not_found_message", true, "top");
            FavoriteItems.Remove(itemData);
          }
        });
        // ReSharper disable once PossibleLossOfFraction
        itemButton.transform.localPosition = new Vector3(50.0f + 40 * (FavoriteItems.IndexOf(itemData) % 5), -20.0f + (FavoriteItems.IndexOf(itemData) / 5) * -40.0f, 0.0f);
        itemButton.gameObject.SetActive(true);
      }
      // ReSharper disable once PossibleLossOfFraction
      content.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 40.0f * (FavoriteItems.Count / 5 + 1));
      if (_itemCacheCheckThread is null || !_itemCacheCheckThread.IsAlive) {
        _itemCacheCheckThread = new Thread(CheckFavoriteItemsStatus) {
          IsBackground = true
        };
        _itemCacheCheckThread.Start();
      }
    }
    
    private static EquipmentButton LoadItemButton(ItemData item, EquipmentButton itemButtonPref, Transform parent, Action<EquipmentButton> callback) {

      string path = $"ui/Icons/items/icon_{item.id}_{item.material}";
      Sprite sprite = Resources.Load<Sprite>(path);
      if (sprite is null) {
        path = $"ui/Icons/items/icon_{item.id}";
        sprite = Resources.Load<Sprite>(path);
      }

      if (sprite is null) {
        return null;
      }

      EquipmentButton itemButton = UnityEngine.Object.Instantiate(itemButtonPref, parent);
      ButtonsToNotAttachTo.Add(itemButton);

      itemButton.load(item);
      itemButton.transform.localPosition = Vector3.zero;

      Button button = itemButton.gameObject.GetComponent<Button>();
      button.onClick.AddListener(() => callback(itemButton));
      
      return itemButton;
    }
  }
}
