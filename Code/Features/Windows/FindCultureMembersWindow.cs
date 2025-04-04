using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using NeoModLoader.api;
using NeoModLoader.General;
using PowerBox.Code.Features.Patches;
using PowerBox.Code.Features.UiHelpers;
using PowerBox.Code.Scheduling;
using PowerBox.Code.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Windows {
  public class FindCultureMembersWindow : WindowBase<FindCultureMembersWindow> {
    public override ModFeatureRequirementList RequiredModFeatures => base.RequiredModFeatures + typeof(Harmony) + typeof(UnitButtonCreator) + typeof(PreventSettingActorToNullInUiUnitAvatarOnDisablePatch);

    protected override ScrollWindow InitObject() {
      ScrollWindow window = WindowCreator.CreateEmptyWindow("powerbox_find_culture_members", "powerbox_find_culture_members");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("powerbox_find_culture_members");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;
      window.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);
      GameObject viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport");
      RectTransform viewportRect = viewport.GetComponent<RectTransform>();
      viewportRect.sizeDelta = new Vector2(0, 17);
      GetFeature<Harmony>().Instance.Patch(
        AccessTools.Method(typeof(StatsWindow), nameof(StatsWindow.create)),
        postfix: new HarmonyMethod(typeof(FindCultureMembersWindow), nameof(HookUpMembersWindow))
      );
      return window;
    }
    private static void HookUpMembersWindow(StatsWindow __instance) {
      if (__instance is CultureWindow cultureWindow) {
        GameObject cultureObject = cultureWindow.gameObject;
        Transform cultureContent = cultureObject.transform.FindRecursive("Background");
        GameObject findCultureMembers = PowerButtonCreator.CreateSimpleButton("powerbox_find_culture_members", Instance.FindCultureMembersButtonClick, Resources.Load<Sprite>("ui/icons/iconculturezones"), cultureContent).gameObject;
        findCultureMembers.transform.localPosition = new Vector3(116.5f, 16.0f, findCultureMembers.transform.localPosition.z);
        Transform editItemsBtnIcon = findCultureMembers.transform.Find("Icon");
        editItemsBtnIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(28f, 28f);
        editItemsBtnIcon.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        RectTransform editItemsRect = findCultureMembers.GetComponent<RectTransform>();
        editItemsRect.sizeDelta = new Vector2(32f, 36f);
        findCultureMembers.GetComponent<Image>().sprite = AssetUtils.LoadEmbeddedSprite("other/backgroundBackButtonRev");
        findCultureMembers.GetComponent<Button>().transition = Selectable.Transition.None;
        Instance.GetFeature<Harmony>().Instance.Unpatch(
          AccessTools.Method(typeof(StatsWindow), nameof(StatsWindow.create)),
          AccessTools.Method(typeof(FindCultureMembersWindow), nameof(HookUpMembersWindow))
        );
      }
    }
    private void FindCultureMembersButtonClick() {
      InitFindCultureMembers(Window);
      Window.clickShow();
    }
    private static List<Actor> GetCultureFollowers(Culture selectedCulture) {
      return World.world.units.getSimpleList().Where(unit => unit.data.culture == selectedCulture.data.id).ToList();
    }
    private void InitFindCultureMembers(ScrollWindow window, Culture selectedCulture = null, Action onFinishAction = null) {
      if (selectedCulture is null) {
        selectedCulture = Config.selected_culture;
      }
      if (selectedCulture is null) {
        PowerBox.LogWarning("InitFindCultureMembers() called with no culture selected");
        return;
      }
      RectTransform rt = SpriteHighlighter.GetComponent<RectTransform>();
      rt.sizeDelta = new Vector2(60f, 60f);

      GameObject content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/" + window.name + "/Background/Scroll View/Viewport/Content");
      window.resetScroll();
      List<Actor> cultureFollowers = GetCultureFollowers(selectedCulture);
      List<Action> uiActions = new List<Action>();
      content.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 40.0f);
      uiActions.Add(window.resetScroll);
      uiActions.Add(content.transform.DetachChildren);
      uiActions.Add(window.resetScroll);
      uiActions.AddRange(cultureFollowers.Select((unit, index) => (Action)(() => {
          GetFeature<UnitButtonCreator>().CreateUnitButton(unit, index, content);
          if (index % 5 == 0) {
            // ReSharper disable once PossibleLossOfFraction
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 40.0f * (index / 5 + 1));
          }
        }))
      );
      uiActions.Add(() => {
        // ReSharper disable once PossibleLossOfFraction
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 40.0f * (cultureFollowers.Count / 5 + 1));
      });
      if (onFinishAction != null) {
        uiActions.Add(onFinishAction);
      }
      Scheduler.Instance.Schedule(new Schedule(10, uiActions.ToArray()));
    }
  }
}
