using System;
using System.Collections.Generic;
using System.Linq;
using NeoModLoader.General;
using PowerBox.Code.Scheduling;
using PowerBox.Code.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Windows {
  public class FindCultureMembersWindow : WindowBase<FindCultureMembersWindow> {
    protected override ScrollWindow InitObject() {
      GameObject cultureObject = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/culture");
      Transform cultureContent = cultureObject.transform.Find("/Canvas Container Main/Canvas - Windows/windows/culture/Background");
      cultureObject.SetActive(false);
      ScrollWindow window = WindowCreator.CreateEmptyWindow("powerbox_find_culture_members", "powerbox_find_culture_members");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("powerbox_find_culture_members");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;

      window.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);

      GameObject findCultureMembers = PowerButtonCreator.CreateSimpleButton("powerbox_find_culture_members", FindCultureMembersButtonClick, Resources.Load<Sprite>("ui/icons/iconculturezones"), cultureContent).gameObject;

      GameObject viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport");
      RectTransform viewportRect = viewport.GetComponent<RectTransform>();
      viewportRect.sizeDelta = new Vector2(0, 17);


      findCultureMembers.transform.localPosition = new Vector3(116.5f, 16.0f, findCultureMembers.transform.localPosition.z);

      Transform editItemsBtnIcon = findCultureMembers.transform.Find("Icon");
      editItemsBtnIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(28f, 28f);
      editItemsBtnIcon.transform.localScale = new Vector3(0.8f, 0.8f, 1);

      RectTransform editItemsRect = findCultureMembers.GetComponent<RectTransform>();
      editItemsRect.sizeDelta = new Vector2(32f, 36f);
      findCultureMembers.GetComponent<Image>().sprite = AssetUtils.LoadEmbeddedSprite("other/backgroundBackButtonRev");
      findCultureMembers.GetComponent<Button>().transition = Selectable.Transition.None;
      return window;
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
      uiActions.AddRange(cultureFollowers.Select((t, i) => i).
        Select(index => (Action)(() => {
          CreateFollowerButton(cultureFollowers, index, content);
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
    private static void CreateFollowerButton(IReadOnlyList<Actor> cultureFollowers, int index, GameObject content) {
      Actor follower = cultureFollowers[index];
      GameObject followerInfo = new GameObject {
        name = "follower_" + index + "_info",
        transform = {
          parent = content.transform,
          // ReSharper disable once PossibleLossOfFraction
          localPosition = new Vector3(50.0f + 40 * (index % 5), -20.0f + (index / 5) * -40.0f, 0.0f),
          localScale = new Vector3(0.9f, 0.9f, 0.9f)
        }
      };
      GameObject followerInfoChild = PowerButtonCreator.CreateSimpleButton("follower_" + index, () => {
        if (follower is null || follower.isAlive() == false || World.world.units.getSimpleList().Contains(follower) == false) {
          return;
        }
        SelectedUnit.select(follower);
        ScrollWindow.showWindow("inspect_unit");
      }, null, followerInfo.transform).gameObject;
      followerInfoChild.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      UiUnitAvatarElement creatureInfo = followerInfoChild.AddComponent<UiUnitAvatarElement>();
      GameObject garbage = new GameObject();
      Image unitTypeBg = garbage.GetComponent<Image>();
      creatureInfo.unit_type_bg = unitTypeBg ?? garbage.AddComponent<Image>();
      creatureInfo.avatarLoader = creatureInfo.gameObject.AddComponent<UnitAvatarLoader>();
      creatureInfo.show_banner_kingdom = false;
      creatureInfo.show_banner_clan = false;
      creatureInfo.Start();
      creatureInfo.show(follower);
      creatureInfo.unit_type_bg = null;
      UnityEngine.Object.Destroy(garbage);
      followerInfoChild.transform.GetChild(0).name = "follower_" + index + "_avatar";
      followerInfoChild.transform.GetChild(0).localPosition = new Vector3(0.0f, -10.0f, 0.0f);
      if (follower.asset.is_boat) {
        followerInfo.transform.GetChild(0).localScale = new Vector3(1.5f, 1.5f, 1.5f);
      } else {
        followerInfoChild.transform.GetChild(0).localScale = new Vector3(2.2f, 2.2f, 2.2f);
      }
      for (int j = 1; j < followerInfoChild.transform.childCount; j++) {
        UnityEngine.Object.Destroy(followerInfoChild.transform.GetChild(j).gameObject);
      }
      LM.AddToCurrentLocale(followerInfoChild.name, follower.coloredName);
      creatureInfo.gameObject.SetActive(true);
    }
  }
}
