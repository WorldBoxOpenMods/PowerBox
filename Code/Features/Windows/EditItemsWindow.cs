using System;
using System.Collections.Generic;
using System.Linq;
using NeoModLoader.General;
using NeoModLoader.services;
using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.Utils;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace PowerBox.Code.Features.Windows {
  internal class EditItemsWindow : WindowBase<EditItemsWindow> {
    internal override List<Type> RequiredFeatures => new List<Type> { typeof(ItemAdditionPower), typeof(ItemRemovalPower) };
    internal override bool Init() {
      if (!base.Init()) return false;
      ScrollWindow.checkWindowExist("inspect_unit");
      GameObject inspectUnitObject = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/inspect_unit");
      Transform inspectUnitContent = inspectUnitObject.transform.Find("/Canvas Container Main/Canvas - Windows/windows/inspect_unit/Background");
      inspectUnitObject.SetActive(false);
      Init(inspectUnitContent);
      return true;
    }

    private GameObject _changeItemType;
    private ScrollWindow _editItemsWindow;
    private GameObject _changeItemModifierF;
    private GameObject _changeItemModifierS;
    private GameObject _changeItemModifierT;
    private void Init(Transform inspectUnitContent) {
      InitAddRemoveChosen();

      _editItemsWindow = WindowCreator.CreateEmptyWindow("edit_items", "edit_items");
      _editItemsWindow.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("edit_items");
      _editItemsWindow.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;

      _editItemsWindow.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);

      GameObject editItems = PowerButtonCreator.CreateSimpleButton("EditItems", EditItemsButtonClick, AssetUtils.LoadEmbeddedSprite("powers/items"), inspectUnitContent).gameObject;

      GameObject viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{_editItemsWindow.name}/Background/Scroll View/Viewport");
      RectTransform viewportRect = viewport.GetComponent<RectTransform>();
      viewportRect.sizeDelta = new Vector2(0, 17);


      editItems.transform.localPosition = new Vector3(117.0f, -35.0f, editItems.transform.localPosition.z);

      Transform editItemsBtnIcon = editItems.transform.Find("Icon");
      editItemsBtnIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(28f, 28f);
      editItemsBtnIcon.transform.localScale = new Vector3(0.8f, 0.8f, 1);

      RectTransform editItemsRect = editItems.GetComponent<RectTransform>();
      editItemsRect.sizeDelta = new Vector2(32f, 36f);
      editItems.GetComponent<Image>().sprite = AssetUtils.LoadEmbeddedSprite("other/backgroundBackButtonRev");
      editItems.GetComponent<Button>().transition = Selectable.Transition.None;

      Transform bg = _editItemsWindow.transform.Find("Background");
      
      GameObject saveButton = PowerButtonCreator.CreateSimpleButton(
        "DoneItems",
        ItemsSaveButtonClick,
        Resources.Load<Sprite>("ui/icons/iconsavelocal"),
        bg.transform
      ).gameObject;
      saveButton.transform.localPosition = new Vector2(70.00f, -150.00f);

      _changeItemType = PowerButtonCreator.CreateSimpleButton(
        "ChangeType",
        ChangeTypeButtonClick,
        AssetUtils.LoadEmbeddedSprite("powers/weapons"),
        bg
      ).gameObject;
      _changeItemType.transform.localPosition = new Vector2(35.00f, -150.00f);

      _changeItemModifierF = PowerButtonCreator.CreateSimpleButton(
        "ChangeModifier0",
        () => ChangeModifierButtonClick(0, _changeItemModifierF),
        AssetUtils.LoadEmbeddedSprite("powers/prefix"),
        bg
      ).gameObject;
      _changeItemModifierF.transform.localPosition = new Vector2(-70.00f, -150.00f);

      _changeItemModifierS = PowerButtonCreator.CreateSimpleButton(
        "ChangeModifier1",
        () => ChangeModifierButtonClick(1, _changeItemModifierS),
        AssetUtils.LoadEmbeddedSprite("powers/prefix"),
        bg
      ).gameObject;
      _changeItemModifierS.transform.localPosition = new Vector2(-35.00f, -150.00f);

      _changeItemModifierT = PowerButtonCreator.CreateSimpleButton(
        "ChangeModifier2",
        () => ChangeModifierButtonClick(2, _changeItemModifierT),
        AssetUtils.LoadEmbeddedSprite("powers/prefix"),
        bg
      ).gameObject;
      _changeItemModifierT.transform.localPosition = new Vector2(0.00f, -150.00f);
      for (int i = 0; i < _chosenModifierIndex.Length; i++) {
        string localeKey = $"ChangeModifier{i}";
        List<ItemAsset> pool = AssetManager.items_modifiers.list.Where(a => a.pool.Contains("weapon")).ToList();
        if (!_modifierLocalesStorage.TryGetValue(localeKey, out string templateLocale)) {
          _modifierLocalesStorage.Add(localeKey, LM.Get(localeKey));
          LM.AddToCurrentLocale(localeKey, string.Format(LM.Get(localeKey), pool[_chosenModifierIndex[i]].id));
        } else {
          LM.AddToCurrentLocale($"ChangeModifier{i}", string.Format(templateLocale, pool[_chosenModifierIndex[i]].id));
        }
      }
    }

    [Obsolete("TODO: Rewrite this abomination to not be a dysfunctional piece of garbage")]
    internal void InitEditItems(ScrollWindow window, Action<EquipmentButton> callback, PowerType powType = PowerType.Unset) {
      PowType = powType;

      if (PowType != PowerType.Unset) {
        callback = AddRemoveItemsButtonCallBack;
      }

      RectTransform rt = SpriteHighlighter.GetComponent<RectTransform>();
      rt.sizeDelta = new Vector2(60f, 60f);

      GameObject content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/" + window.name + "/Background/Scroll View/Viewport/Content");
      for (int i = 0; i < content.transform.childCount; i++) {
        Object.Destroy(content.transform.GetChild(i).gameObject);
      }
      ScrollWindow.allWindows.TryGetValue("inspect_unit", out ScrollWindow inspectUnit);
      if (inspectUnit is null) {
        return;
      }
      WindowCreatureInfo windowCreatureInfo = inspectUnit.GetComponent<WindowCreatureInfo>();
      EquipmentButton itemButton = windowCreatureInfo.prefabEquipment;

      List<ItemAsset> itemsList = AssetManager.items.list.FindAll(c => _chosenType == EquipmentType.Weapon ? c.equipmentType == EquipmentType.Weapon : c.equipmentType != EquipmentType.Weapon);

      List<ItemAsset> materials;
      switch (_chosenType) {
        case EquipmentType.Weapon:
          materials = AssetManager.items_material_weapon.list;
          break;
        case EquipmentType.Helmet:
        case EquipmentType.Armor:
        case EquipmentType.Boots:
        case EquipmentType.Ring:
        case EquipmentType.Amulet:
        default:
          materials = AssetManager.items_material_armor.list;
          break;
      }


      XStep = 24.75f;
      CountInRow = 8;

      int index = 0;

      List<string> skipList = new List<string> {
        "_equipment", "_accessory", "_weapon", "_melee", "_range", "base", "hands", "jaws", "claws"
      };

      Dictionary<ItemData, bool> addItemSelectionFound = ChosenForAddSlots.Where(selection => selection.Value != null).ToDictionary(selection => selection.Value, _ => false);
      Dictionary<ItemData, bool> removeItemSelectionFound = ChosenForRemoveSlots.Where(selection => selection.Value != null).ToDictionary(selection => selection.Value, _ => false);


      RectTransform rect = content.GetComponent<RectTransform>();
      rect.pivot = new Vector2(0, 1);
      rect.sizeDelta = new Vector2(0, Mathf.Abs(GetPosByIndex(itemsList.Where(item => !skipList.Contains(item.id)).SelectMany(item => item.materials.Select(material => (item, new ItemData() { id = item.id, material = material }))).Count(itemTuple => itemTuple.Item1.getSprite(itemTuple.Item2) != null)).y));

      foreach (ItemAsset item in itemsList.Where(item => !skipList.Contains(item.id))) {
        foreach (ItemAsset material in materials) {
          ItemData itemData = new ItemData {
            id = item.id,
            by = "Nikon"
          };
          bool ringAndAmulet = ((itemData.id == "ring" || itemData.id == "amulet") && material.id == "leather");
          itemData.material = ringAndAmulet ? "bone" : material.id;
          itemData.modifiers = new List<string> {
            _chosenModifierId[0],
            _chosenModifierId[1],
            _chosenModifierId[2]
          }.Where(mod => mod != null).Where(mod => mod != "").Where(mod => mod != "normal").ToList();

          if (!item.materials.Contains(material.id) && !ringAndAmulet) {
            continue;
          }

          if (item.getSprite(itemData) == null) {
            continue;
          }

          if (PowType != PowerType.Unset) {
            if (ChosenForAddSlots[item.equipmentType] != null) {
              if (CompareItems(ChosenForAddSlots[item.equipmentType], itemData)) {
                addItemSelectionFound[ChosenForAddSlots[item.equipmentType]] = true;
              }
            }
            if (ChosenForRemoveSlots[item.equipmentType] != null) {
              if (CompareItems(ChosenForRemoveSlots[item.equipmentType], itemData)) {
                removeItemSelectionFound[ChosenForRemoveSlots[item.equipmentType]] = true;
              }
            }
          }
        }
      }

      switch (PowType) {
        case PowerType.Add:
          foreach (KeyValuePair<ItemData, bool> selection in addItemSelectionFound.Where(selection => !selection.Value)) {
            LoadItemButton(selection.Key, itemButton, AddHighLight(index++, content, true).transform, callback);
          }
          break;
        case PowerType.Remove:
          foreach (KeyValuePair<ItemData, bool> selection in removeItemSelectionFound.Where(selection => !selection.Value)) {
            LoadItemButton(selection.Key, itemButton, AddHighLight(index++, content, true).transform, callback);
          }
          break;
        case PowerType.Unset:
        default:
          break;
      }

      if (index != 0) index = (index / CountInRow + 1) * CountInRow;

      foreach (ItemAsset item in itemsList.Where(item => !skipList.Contains(item.id))) {
        foreach (ItemAsset material in materials) {
          ItemData itemData = new ItemData {
            id = item.id,
            by = "Nikon"
          };
          bool ringAndAmulet = ((itemData.id == "ring" || itemData.id == "amulet") && material.id == "leather");
          itemData.material = ringAndAmulet ? "bone" : material.id;
          itemData.modifiers = new List<string> {
            _chosenModifierId[0],
            _chosenModifierId[1],
            _chosenModifierId[2]
          }.Where(mod => mod != null).Where(mod => mod != "").Where(mod => mod != "normal").ToList();

          if (!item.materials.Contains(material.id) && !ringAndAmulet) {
            continue;
          }

          if (item.getSprite(itemData) == null) {
            continue;
          }

          GameObject hl;
          if (PowType == PowerType.Unset) {
            ActorEquipmentSlot actorsItem = ActorEquipment.getList(Config.selectedUnit.equipment).Find(c => c.data.id == itemData.id);
            bool compare = actorsItem?.data != null && CompareItems(actorsItem.data, itemData);
            hl = AddHighLight(index, content, compare);
          } else {
            bool addCond = false;
            bool removeCond = false;

            if (ChosenForAddSlots[item.equipmentType] != null) {
              addCond = CompareItems(ChosenForAddSlots[item.equipmentType], itemData);
            }

            if (ChosenForRemoveSlots[item.equipmentType] != null) {
              removeCond = CompareItems(ChosenForRemoveSlots[item.equipmentType], itemData);
            }

            hl = AddHighLight(index, content, PowType == PowerType.Add ? addCond : removeCond);
          }

          LoadItemButton(itemData, itemButton, hl.transform, callback);
          index++;
        }
      }
    }

    private static void LoadItemButton(ItemData item, EquipmentButton itemButtonPref, Transform parent, Action<EquipmentButton> callback) {
      EquipmentButton itemButton = Object.Instantiate(itemButtonPref, parent);
      FindFavouriteItemsWindow.AddButtonToNotAttachTo(itemButton);

      try {
        itemButton.load(item);
      } catch (Exception e) {
        Debug.LogWarning("Failed to load button for item " + item.id + ", it might show up in an unintended way. Error that caused this:\n\n" + e);
      }

      itemButton.transform.localPosition = Vector3.zero;

      Button button = itemButton.gameObject.GetComponent<Button>();
      button.onClick.AddListener(() => callback(itemButton));
    }

    internal static bool CompareItems(ItemData item1, ItemData item2) {
      return item1.id == item2.id && item1.by == item2.by && item1.material == item2.material && item1.modifiers.All(modifier => item2.modifiers.Contains(modifier)) && item2.modifiers.All(modifier => item1.modifiers.Contains(modifier));
    }

    private EquipmentType _chosenType = EquipmentType.Weapon;
    private void ChangeTypeButtonClick() {
      switch (_chosenType) {
        case EquipmentType.Weapon:
          _chosenType = EquipmentType.Armor;
          break;
        case EquipmentType.Helmet:
        case EquipmentType.Armor:
        case EquipmentType.Boots:
        case EquipmentType.Ring:
        case EquipmentType.Amulet:
        default:
          _chosenType = EquipmentType.Weapon;
          break;
      }
      SwapModifiers();
      if (_chosenType == EquipmentType.Weapon) {
        _changeItemType.transform.Find("Icon").GetComponent<Image>().sprite = AssetUtils.LoadEmbeddedSprite("powers/weapons");
        LM.AddToCurrentLocale("ChangeType", LM.Get("WeaponsChangeType"));
      } else {
        _changeItemType.transform.Find("Icon").GetComponent<Image>().sprite = AssetUtils.LoadEmbeddedSprite("powers/armor");
        LM.AddToCurrentLocale("ChangeType", LM.Get("ArmorChangeType"));
      }
      if (PowType == PowerType.Unset) {
        InitEditItems(_editItemsWindow, EditItemsButtonCallBack);
      } else {
        InitEditItems(_editItemsWindow, null, PowType);
      }
    }
    private int[] _inactiveChosenModifierIndex = { 0, 0, 0 };
    private string[] _inactiveChosenModifierId = { "normal", "normal", "normal" };
    private int[] _chosenModifierIndex = { 0, 0, 0 };
    private string[] _chosenModifierId = { "normal", "normal", "normal" };
    private readonly Dictionary<string, string> _modifierLocalesStorage = new Dictionary<string, string>();
    private void SwapModifiers() {
      int[] tempIndex = _chosenModifierIndex;
      string[] tempId = _chosenModifierId;
      _chosenModifierIndex = _inactiveChosenModifierIndex;
      _chosenModifierId = _inactiveChosenModifierId;
      _inactiveChosenModifierIndex = tempIndex;
      _inactiveChosenModifierId = tempId;
      string poolName;
      switch (_chosenType) {
        case EquipmentType.Weapon:
          poolName = "weapon";
          break;
        case EquipmentType.Helmet:
        case EquipmentType.Armor:
        case EquipmentType.Boots:
        case EquipmentType.Ring:
        case EquipmentType.Amulet:
        default:
          poolName = "armor,accessory";
          break;
      }
      List<ItemAsset> pool = poolName.Split(',').SelectMany(n => AssetManager.items_modifiers.list.Where(i => i.pool.Contains(n))).ToList();
      for (int i = 0; i < _chosenModifierIndex.Length; i++) {
        string localeKey = $"ChangeModifier{i}";
        if (!_modifierLocalesStorage.TryGetValue(localeKey, out string templateLocale)) {
          _modifierLocalesStorage.Add(localeKey, LM.Get(localeKey));
          LM.AddToCurrentLocale(localeKey, string.Format(LM.Get(localeKey), pool[_chosenModifierIndex[i]].id));
        } else {
          LM.AddToCurrentLocale($"ChangeModifier{i}", string.Format(templateLocale, pool[_chosenModifierIndex[i]].id));
        }
      }
    }
    private void ChangeModifierButtonClick(int modifierIndexNumber, GameObject itemModifierButton) {
      string poolName;

      switch (_chosenType) {
        case EquipmentType.Weapon:
          poolName = "weapon";
          break;
        case EquipmentType.Helmet:
        case EquipmentType.Armor:
        case EquipmentType.Boots:
        case EquipmentType.Ring:
        case EquipmentType.Amulet:
        default:
          poolName = "armor,accessory";
          break;
      }
      List<ItemAsset> pool = poolName.Split(',').SelectMany(n => AssetManager.items_modifiers.list.Where(i => i.pool.Contains(n))).ToList();

      while (true) {
        _chosenModifierIndex[modifierIndexNumber]++;


        if (_chosenModifierIndex[modifierIndexNumber] >= pool.Count) {
          _chosenModifierIndex[modifierIndexNumber] = 0;
        }

        if (_chosenModifierId[modifierIndexNumber] != pool[_chosenModifierIndex[modifierIndexNumber]].id) {
          _chosenModifierId[modifierIndexNumber] = pool[_chosenModifierIndex[modifierIndexNumber]].id;
          break;
        }
      }

      string localeKey = $"ChangeModifier{modifierIndexNumber}";
      if (!_modifierLocalesStorage.TryGetValue(localeKey, out string templateLocale)) {
        _modifierLocalesStorage.Add(localeKey, LM.Get(localeKey));
        LM.AddToCurrentLocale(localeKey, string.Format(LM.Get(localeKey), pool[_chosenModifierIndex[modifierIndexNumber]].id));
      } else {
        LM.AddToCurrentLocale($"ChangeModifier{modifierIndexNumber}", string.Format(templateLocale, pool[_chosenModifierIndex[modifierIndexNumber]].id));
      }
      itemModifierButton.GetComponent<PowerButton>().showTooltip();
      if (PowType == PowerType.Unset) {
        InitEditItems(_editItemsWindow, EditItemsButtonCallBack);
      } else {
        InitEditItems(_editItemsWindow, null, PowType);
      }
    }

    private void EditItemsButtonClick() {
      if (Config.selectedUnit != null && Config.selectedUnit.asset.use_items) {
        InitEditItems(_editItemsWindow, EditItemsButtonCallBack);
        _editItemsWindow.clickShow();
      } else {
        WorldTip.showNow("cant_use_items_error", true, "top");
      }
    }

    private void EditItemsButtonCallBack(EquipmentButton buttonPressed) {
      ItemData data = buttonPressed.item_data;
      data.modifiers = data.modifiers.Where(mod => mod != null).Where(mod => mod != "").Where(mod => mod != "normal").ToList();
      ActorEquipmentSlot unitSlot = Config.selectedUnit.equipment.getSlot(AssetManager.items.get(data.id).equipmentType);

      if (unitSlot.data != null) {
        if (CompareItems(data, data)) {
          unitSlot.emptySlot();
        } else {
          unitSlot.setItem(data.Clone());
        }
      } else {
        unitSlot.setItem(data.Clone());
      }

      Config.selectedUnit.setStatsDirty();


      ScrollWindow.allWindows.TryGetValue("edit_items", out ScrollWindow window);
      if (window is null) {
        return;
      }
      InitEditItems(window, EditItemsButtonCallBack);
    }

    internal static readonly Dictionary<EquipmentType, ItemData> ChosenForAddSlots = new Dictionary<EquipmentType, ItemData>();
    internal static readonly Dictionary<EquipmentType, ItemData> ChosenForRemoveSlots = new Dictionary<EquipmentType, ItemData>();

    private void AddRemoveItemsButtonCallBack(EquipmentButton buttonPressed) {
      ItemData data = buttonPressed.item_data;
      EquipmentType type = AssetManager.items.get(data.id).equipmentType;

      switch (PowType) {
        case PowerType.Add:
          if (ChosenForAddSlots[type] != null && CompareItems(ChosenForAddSlots[type], data)) {
            ChosenForAddSlots[type] = null;
          } else {
            ChosenForAddSlots[type] = data;
          }
          break;
        case PowerType.Remove:
          if (ChosenForRemoveSlots[type] != null && CompareItems(ChosenForRemoveSlots[type], data)) {
            ChosenForRemoveSlots[type] = null;
          } else {
            ChosenForRemoveSlots[type] = data;
          }
          break;
        case PowerType.Unset:
        default:
          throw new ArgumentOutOfRangeException();
      }
      ScrollWindow.allWindows.TryGetValue("edit_items", out ScrollWindow window);
      if (window is null) {
        return;
      }
      InitEditItems(window, null, PowType);
    }

    private static void InitAddRemoveChosen() {
      ChosenForAddSlots.Add(EquipmentType.Amulet, null);
      ChosenForAddSlots.Add(EquipmentType.Armor, null);
      ChosenForAddSlots.Add(EquipmentType.Boots, null);
      ChosenForAddSlots.Add(EquipmentType.Helmet, null);
      ChosenForAddSlots.Add(EquipmentType.Ring, null);
      ChosenForAddSlots.Add(EquipmentType.Weapon, null);
      ChosenForRemoveSlots.Add(EquipmentType.Amulet, null);
      ChosenForRemoveSlots.Add(EquipmentType.Armor, null);
      ChosenForRemoveSlots.Add(EquipmentType.Boots, null);
      ChosenForRemoveSlots.Add(EquipmentType.Helmet, null);
      ChosenForRemoveSlots.Add(EquipmentType.Ring, null);
      ChosenForRemoveSlots.Add(EquipmentType.Weapon, null);
    }

    private void ItemsSaveButtonClick() {
      ScrollWindow.allWindows.TryGetValue("edit_items", out ScrollWindow addRemoveItemsWindow);
      if (addRemoveItemsWindow is null) {
        return;
      }
      addRemoveItemsWindow.clickHide();

      if (PowType == PowerType.Add && ChosenForAddSlots.Count > 0 || PowType == PowerType.Remove && ChosenForRemoveSlots.Count > 0) {
        GameObject pButtonO = ResourcesFinder.FindResource<GameObject>(PowType == PowerType.Add ? "addItems" : "removeItems");
        if (pButtonO is null) {
          LogService.LogError("Power button object not found");
          LogService.LogStackTraceAsError();
          return;
        }
        PowerButton pButton = pButtonO.GetComponent<PowerButton>();
        if (pButton is null) {
          LogService.LogError("Power button not found");
          LogService.LogStackTraceAsError();
          return;
        }
        if (pButton.godPower is null) {
          pButton.godPower = AssetManager.powers.get(PowType == PowerType.Add ? "addItems" : "removeItems");
        }
        if (pButton.godPower is null) {
          LogService.LogError("Power button godPower not found");
          LogService.LogStackTraceAsError();
          return;
        }
        PowerButtonSelector.instance.clickPowerButton(pButton);
      }
    }
  }
}