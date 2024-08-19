using System.Linq;
using NeoModLoader.General;
using PowerBox.Code.LoadingSystem;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Windows {
  public class EditFavoriteFoodWindow : WindowBase<EditFavoriteFoodWindow> {
    private ScrollWindow _editFavoriteFoodWindow;
    private Actor _targetUnit;
    private Buttons.Tab Tab => FeatureManager.Instance.GetFeature<Buttons.Tab>(this);
    internal override bool Init() {
      ScrollWindow.checkWindowExist("inspect_unit");

      _editFavoriteFoodWindow = WindowCreator.CreateEmptyWindow("edit_favorite_food", "edit_favorite_food");
      _editFavoriteFoodWindow.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("edit_favorite_food");
      _editFavoriteFoodWindow.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;

      _editFavoriteFoodWindow.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);

      GameObject inspectUnitHungerStatBar = ResourcesFinder.FindResource<GameObject>("HungerBar");
      if (inspectUnitHungerStatBar != null) {
        Button inspectUnitHungerStatBarButton = inspectUnitHungerStatBar.GetComponent<Button>();
        if (inspectUnitHungerStatBarButton != null) {
          inspectUnitHungerStatBarButton.onClick.AddListener(EditFavoriteFoodButtonClick);
        }
      }

      GameObject viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{_editFavoriteFoodWindow.name}/Background/Scroll View/Viewport");
      RectTransform viewportRect = viewport.GetComponent<RectTransform>();
      viewportRect.sizeDelta = new Vector2(0, 17);
      
      return true;
    }
    private void EditFavoriteFoodButtonClick() {
      InitEditFavoriteFood(_editFavoriteFoodWindow);
      _editFavoriteFoodWindow.clickShow();
    }

    private void InitEditFavoriteFood(ScrollWindow window) {
      GameObject content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/" + window.name + "/Background/Scroll View/Viewport/Content");
      _targetUnit = Config.selectedUnit;
      if (content.transform.childCount <= 0) {
        foreach (GameObject foodSelectButton in AssetManager.resources.list.Where(r => r.type == ResType.Food).Where(r => r.id != "honey" /* for some reason, honey seems to not have localized text and a sprite */).Select(food => Tab.CreateClickButton(food.id, food.getSprite(), content.transform, () => SetFavoriteFood(food.id)))) {
          int i = content.transform.childCount - 1;
          // ReSharper disable once PossibleLossOfFraction
          foodSelectButton.transform.localPosition = new Vector3(50.0f + 40 * (i % 5), -20.0f + (i / 5) * -40.0f, 0.0f);
        }
        // ReSharper disable once PossibleLossOfFraction
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 40.0f * (content.transform.childCount / 5 + 1));
      }
    }
    
    private void SetFavoriteFood(string foodId) {
      _targetUnit.data.favoriteFood = foodId;
      WorldTip.showNow("favorite_food_set", true, "top");
    }
  }
}