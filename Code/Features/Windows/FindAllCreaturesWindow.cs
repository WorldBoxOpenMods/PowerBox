using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using NeoModLoader.api;
using NeoModLoader.General;
using PowerBox.Code.Features.Prefabs;
using PowerBox.Code.Scheduling;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Windows {
  public class FindAllCreaturesWindow : WindowBase<FindAllCreaturesWindow> {
    public override ModFeatureRequirementList RequiredModFeatures => base.RequiredModFeatures + typeof(UnitAvatarElement);

    protected override ScrollWindow InitObject() {
      ScrollWindow window = WindowCreator.CreateEmptyWindow("powerbox_find_all_creatures", "powerbox_find_all_creatures");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("powerbox_find_all_creatures");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;

      window.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);
      
      GameObject viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport");
      RectTransform viewportRect = viewport.GetComponent<RectTransform>();
      viewportRect.sizeDelta = new Vector2(0, 17);

      new HarmonyLib.Harmony("idc").Patch(
        AccessTools.Method(typeof(Button), "Press"),
        finalizer: new HarmonyMethod(typeof(FindAllCreaturesWindow), nameof(Button_Press_Finalizer))
      );

      return window;
    }
    
    private static Exception Button_Press_Finalizer(Button __instance, Exception __exception) {
      if (__exception != null) {
        Debug.LogError($"Exception in Button of GameObject {__instance.gameObject.name}!");
      }
      return __exception;
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
    private void CreateUnitButton(IReadOnlyList<Actor> units, int index, GameObject content) {
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
      GameObject unitInfoAvatarGameObject = UnityEngine.Object.Instantiate(GetFeature<UnitAvatarElement>().Prefab, unitInfo.transform);
      UiUnitAvatarElement unitInfoAvatar = unitInfoAvatarGameObject.GetComponent<UiUnitAvatarElement>();
      unitInfoAvatar.Start();
      unitInfoAvatar.show(unit);
      unitInfoAvatarGameObject.name = $"unit_{index}_avatar";
      unitInfoAvatarGameObject.transform.localPosition = new Vector3(0.0f, -10.0f, 0.0f);
      List<GameObject> objectsToCheck = new List<GameObject> { unitInfo };
      {
        GameObject go;
        // ReSharper disable once AssignmentInConditionalExpression
        while (go = objectsToCheck.FirstOrDefault()) {
          objectsToCheck.Remove(go);
          objectsToCheck.AddRange(from Transform child in go.transform select child.gameObject);
          Button gob = go.GetComponent<Button>();
          if (gob != null) {
            if (gob.onClick.GetPersistentEventCount() > 0) {
              Debug.Log($"GameObject {go.name} for unit {index} has {gob.onClick.GetPersistentEventCount()} listeners to remove");
            }
            gob.onClick.RemoveAllListeners();
          }
        }
      }
      Button unitInfoAvatarButton = unitInfoAvatarGameObject.transform
        .FindRecursive("Mask")
        .FindRecursive(transform => transform.name.Contains("Avatar") /* exact name of this GO can differ post unit load because it gets renamed based on unit ID */)
        .GetComponent<Button>();
      unitInfoAvatarButton.onClick.AddListener(() => {
        if (unit.isAlive() == false || World.world.units.getSimpleList().Contains(unit) == false) {
          return;
        }
        SelectedUnit.select(unit);
        ScrollWindow.showWindow(S_Window.unit);
      });
      unitInfoAvatarGameObject.transform.FindRecursive("Mask").GetComponent<Button>().onClick.RemoveAllListeners();
      /*if (unit.asset.is_boat) {
        unitInfo.transform.GetChild(0).localScale = new Vector3(1.5f, 1.5f, 1.5f);
      } else {
        unitInfoAvatarGameObject.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
      }*/
      unitInfoAvatar.gameObject.SetActive(true);
    }
  }
}
