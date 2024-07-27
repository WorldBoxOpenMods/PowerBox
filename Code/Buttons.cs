using System.Linq;
using NeoModLoader.General;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code {
  internal static class Buttons {
    internal static void Init() {
      Tab.CreateClickButton(
        "AboutMod",
        Resources.Load<Sprite>("ui/icons/iconabout"),
        Tab.PowerboxTabObject.transform,
        AboutModButtonClick
      );

      GameObject dbgBtn = Tab.CreateClickButton(
        "DebugButtonAdd",
        Resources.Load<Sprite>("ui/icons/icondebug"),
        Tab.PowerboxTabObject.transform,
        DebugButtonAddClick
      );
      Tab.AddHorizontalPadding(9.0f);

      Object.Destroy(dbgBtn.transform.GetComponent<DebugButton>());

      Tab.CreateGodPowerButton(
        "spawnMaximCreature",
        Resources.Load<Sprite>("ui/icons/iconMaximCreature"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "spawnMastefCreature",
        Resources.Load<Sprite>("ui/icons/iconMastefCreature"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "spawnBurgerSpider",
        Resources.Load<Sprite>("ui/icons/iconburgerSpider"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "spawnGregCreature",
        Resources.Load<Sprite>("ui/icons/icongreg"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "spawnTumorCreatureUnit",
        Resources.Load<Sprite>("powers/tumor_unit_icon"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "spawnTumorCreatureAnimal",
        Resources.Load<Sprite>("powers/tumor_animal_icon"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "spawnMushCreatureUnit",
        Resources.Load<Sprite>("powers/mush_unit_icon"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "spawnMushCreatureAnimal",
        Resources.Load<Sprite>("powers/mush_animal_icon"),
        Tab.PowerboxTabObject.transform
      );

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

      Tab.CreateGodPowerButton(
        "upgradeBuildingAdd",
        Resources.Load<Sprite>("powers/upgrade_building_icon"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "downgradeBuildingAdd",
        Resources.Load<Sprite>("powers/downgrade_building_icon"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "expandCitiesBorders",
        Resources.Load<Sprite>("powers/borders1"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "reduceCitiesBorders",
        Resources.Load<Sprite>("powers/borders2"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "expandCultureBorders",
        Resources.Load<Sprite>("powers/culture_borders_plus"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "reduceCultureBorders",
        Resources.Load<Sprite>("powers/culture_borders_minus"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "createCulture",
        Resources.Load<Sprite>("ui/icons/iconculture"),
        Tab.PowerboxTabObject.transform
      );
      
      Tab.CreateGodPowerButton(
        "duplicateCulture",
        Resources.Load<Sprite>("ui/icons/iconCloneCulture"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "addToCulture",
        Resources.Load<Sprite>("ui/icons/iconculturezones"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "makeColony",
        Resources.Load<Sprite>("powers/colonies"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "friendshipNR",
        Resources.Load<Sprite>("ui/icons/iconfriendship"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "addToClan",
        Resources.Load<Sprite>("ui/icons/iconclanzones"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "spawn_boat_fishing",
        Resources.Load<Sprite>("actors/boats/boat_fishing"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "spawn_boat_transport",
        Resources.Load<Sprite>("actors/boats/boat_trading_dwarf"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "spawn_boat_trading",
        Resources.Load<Sprite>("actors/boats/boat_transport_dwarf"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "bloodRainCloudSpawn",
        Resources.Load<Sprite>("powers/blood_rain"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "burgerSpiderCloudSpawn",
        Resources.Load<Sprite>("powers/burgerspider_rain"),
        Tab.PowerboxTabObject.transform
      );

      Tab.CreateGodPowerButton(
        "create_alliance",
        Resources.Load<Sprite>("ui/icons/iconalliance"),
        Tab.PowerboxTabObject.transform
      );
    }

    private static void AboutModButtonClick() {
      ScrollWindow.showWindow("aboutPowerBox");
    }


    private static void DebugButtonAddClick() {
      ResourcesFinder.FindResources<GameObject>("DebugButton").FirstOrDefault()?.GetComponent<Button>().onClick.Invoke();
    }

    private static void AddItemsButtonClick() {
      ItemsButtonClick(PowerType.Add);
    }

    private static void RemoveItemsButtonCLick() {
      ItemsButtonClick(PowerType.Remove);
    }

    private static void ItemsButtonClick(PowerType type) {
      if (ScrollWindow.allWindows.TryGetValue("edit_items", out ScrollWindow editItemsWindow)) {
        Windows.EditItemsWindow.InitEditItems(editItemsWindow, null, type);
        editItemsWindow.clickShow();
      }
    }
  }
}