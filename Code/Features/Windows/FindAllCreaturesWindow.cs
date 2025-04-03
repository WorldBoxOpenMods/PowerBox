using System;
using System.Collections.Generic;
using System.Linq;
using NeoModLoader.General;
using PowerBox.Code.Scheduling;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Windows {
  public class FindAllCreaturesWindow : WindowBase<FindAllCreaturesWindow> {
    protected override ScrollWindow InitObject() {
      ScrollWindow window = WindowCreator.CreateEmptyWindow("powerbox_find_all_creatures", "powerbox_find_all_creatures");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("powerbox_find_all_creatures");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;

      window.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);
      
      GameObject viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport");
      RectTransform viewportRect = viewport.GetComponent<RectTransform>();
      viewportRect.sizeDelta = new Vector2(0, 17);
      
      return window;
    }
    
    public void FindAllCreaturesButtonClick() {
      InitFindAllCreatures();
      Window.clickShow();
    }
    
    private static List<Actor> GetAllUnits() {
      return World.world.units.getSimpleList().ToList();
    }
    private void InitFindAllCreatures(Action onFinishAction = null) {
      RectTransform rt = SpriteHighlighter.GetComponent<RectTransform>();
      rt.sizeDelta = new Vector2(60f, 60f);
      GameObject content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/" + Window.name + "/Background/Scroll View/Viewport/Content");
      Window.resetScroll();
      List<Actor> units = GetAllUnits();
      List<Action> uiActions = new List<Action>();
      content.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 40.0f);
      uiActions.Add(Window.resetScroll);
      uiActions.Add(content.transform.DetachChildren);
      uiActions.Add(Window.resetScroll);
      uiActions.AddRange(units.Select((t, i) => i).
        Select(index => (Action)(() => {
          CreateUnitButton(units, index, content);
          if (index % 5 == 0) {
            // ReSharper disable once PossibleLossOfFraction
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 40.0f * (index / 5 + 1));
          }
        }))
      );
      uiActions.Add(() => {
        // ReSharper disable once PossibleLossOfFraction
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 40.0f * (units.Count / 5 + 1));
      });
      if (onFinishAction != null) {
        uiActions.Add(onFinishAction);
      }
      Scheduler.Instance.Schedule(new Schedule(10, uiActions.ToArray()));
    }
    private static void CreateUnitButton(IReadOnlyList<Actor> units, int index, GameObject content) {
      Actor unit = units[index];
      if (unit?.asset is null) {
        return;
      }
      GameObject unitInfo = new GameObject {
        name = "unit_" + index + "_info",
        transform = {
          parent = content.transform,
          // ReSharper disable once PossibleLossOfFraction
          localPosition = new Vector3(50.0f + 40 * (index % 5), -20.0f + (index / 5) * -40.0f, 0.0f),
          localScale = new Vector3(0.9f, 0.9f, 0.9f)
        }
      };
      GameObject followerInfoChild = PowerButtonCreator.CreateSimpleButton("unit_" + index, () => {
        if (unit.isAlive() == false || World.world.units.getSimpleList().Contains(unit) == false) {
          return;
        }
        SelectedUnit.select(unit);
        ScrollWindow.showWindow(S_Window.unit);
      }, null, unitInfo.transform).gameObject;
      followerInfoChild.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      UiUnitAvatarElement creatureInfo = followerInfoChild.AddComponent<UiUnitAvatarElement>();
      GameObject garbage = new GameObject();
      Image unitTypeBg = garbage.GetComponent<Image>();
      creatureInfo.unit_type_bg = unitTypeBg ?? garbage.AddComponent<Image>();
      creatureInfo.avatarLoader = creatureInfo.gameObject.AddComponent<UnitAvatarLoader>();
      creatureInfo.avatarLoader._item_image = creatureInfo.unit_type_bg;
      creatureInfo.avatarLoader._actor_image = followerInfoChild.GetComponent<Image>() ?? followerInfoChild.AddComponent<Image>();
      creatureInfo.avatarLoader._actor_and_item_container = garbage.GetComponent<RectTransform>() ?? garbage.AddComponent<RectTransform>();
      creatureInfo.show_banner_kingdom = false;
      creatureInfo.show_banner_clan = false;
      creatureInfo.Start();
      creatureInfo.show(unit);
      creatureInfo.unit_type_bg = null;
      UnityEngine.Object.Destroy(garbage);
      followerInfoChild.transform.GetChild(0).name = "unit_" + index + "_avatar";
      followerInfoChild.transform.GetChild(0).localPosition = new Vector3(0.0f, -10.0f, 0.0f);
      if (unit.asset.is_boat) {
        unitInfo.transform.GetChild(0).localScale = new Vector3(1.5f, 1.5f, 1.5f);
      } else {
        followerInfoChild.transform.GetChild(0).localScale = new Vector3(2.2f, 2.2f, 2.2f);
      }
      for (int j = 1; j < followerInfoChild.transform.childCount; j++) {
        UnityEngine.Object.Destroy(followerInfoChild.transform.GetChild(j).gameObject);
      }
      LM.AddToCurrentLocale(followerInfoChild.name, unit.coloredName);
      creatureInfo.gameObject.SetActive(true);
    }
  }
}
