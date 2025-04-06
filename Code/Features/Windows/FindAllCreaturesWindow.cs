using System;
using System.Collections.Generic;
using System.Linq;
using NeoModLoader.api;
using NeoModLoader.General;
using PowerBox.Code.Features.Patches;
using PowerBox.Code.Features.UiHelpers;
using PowerBox.Code.Scheduling;
using PowerBox.Code.Utils;
using UnityEngine;

namespace PowerBox.Code.Features.Windows {
  public class FindAllCreaturesWindow : WindowBase<FindAllCreaturesWindow> {
    public override ModFeatureRequirementList RequiredModFeatures => base.RequiredModFeatures + typeof(UnitButtonCreator) + typeof(PreventSettingActorToNullInUiUnitAvatarOnDisablePatch);

    protected override ScrollWindow InitObject() {
      ScrollWindow window = WindowCreator.CreateEmptyWindow("powerbox_find_all_creatures", "powerbox_find_all_creatures", "iconbrowse2");
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
      GameObject content = Window.GetContentGameObject();
      Window.resetScroll();
      List<Actor> units = GetAllUnits();
      List<Action> uiActions = new List<Action>();
      content.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 40.0f);
      uiActions.Add(Window.resetScroll);
      uiActions.Add(content.transform.DetachChildren);
      uiActions.Add(Window.resetScroll);
      uiActions.AddRange(units.Select((unit, index) => (Action)(() => {
          GetFeature<UnitButtonCreator>().CreateUnitButton(unit, index, content);
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
  }
}
