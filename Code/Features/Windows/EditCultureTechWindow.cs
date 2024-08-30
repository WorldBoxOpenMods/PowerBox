using System;
using NeoModLoader.General;
using NeoModLoader.General.UI.Prefabs;
using PowerBox.Code.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Windows {
  public class EditCultureTechWindow : WindowBase<EditCultureTechWindow> {
    protected override ScrollWindow InitObject() {
      ScrollWindow.checkWindowExist("culture");
      GameObject cultureObject = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/culture");
      Transform cultureContent = cultureObject.transform.Find("/Canvas Container Main/Canvas - Windows/windows/culture/Background");
      cultureObject.SetActive(false);
      ScrollWindow window = WindowCreator.CreateEmptyWindow("powerbox_edit_culture_tech", "powerbox_edit_culture_tech");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("powerbox_edit_culture_tech");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;

      window.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);

      GameObject editCultureTechButton = PowerButtonCreator.CreateSimpleButton(
        "powerbox_edit_culture_tech_button",
        EditCultureTechButtonClick,
        Resources.Load<Sprite>("ui/icons/iconculture"),
        cultureContent
      ).gameObject;

      GameObject viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport");
      RectTransform viewportRect = viewport.GetComponent<RectTransform>();
      viewportRect.sizeDelta = new Vector2(0, 17);


      editCultureTechButton.transform.localPosition = new Vector3(116.5f, -22.8f, editCultureTechButton.transform.localPosition.z);

      Transform editItemsBtnIcon = editCultureTechButton.transform.Find("Icon");
      editItemsBtnIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(28f, 28f);
      editItemsBtnIcon.transform.localScale = new Vector3(0.8f, 0.8f, 1);

      RectTransform editItemsRect = editCultureTechButton.GetComponent<RectTransform>();
      editItemsRect.sizeDelta = new Vector2(32f, 36f);
      editCultureTechButton.GetComponent<Image>().sprite = AssetUtils.LoadEmbeddedSprite("other/backgroundBackButtonRev");
      editCultureTechButton.GetComponent<Button>().transition = Selectable.Transition.None;
      StartXPos = 60.0f;
      CountInRow = 1;
      XStep = 0.0f;
      YStep = -20.0f;
      return window;
    }

    private void EditCultureTechButtonClick() {
      Culture selectedCulture = Config.selectedCulture;
      if (selectedCulture == null) {
        WorldTip.showNow("no_culture_selected_error", true, "top");
        return;
      }
      GameObject content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/" + Window.name + "/Background/Scroll View/Viewport/Content");
      Window.resetScroll();
      for (int i = 0; i < content.transform.childCount; i++) {
        UnityEngine.Object.Destroy(content.transform.GetChild(i).gameObject);
      }
      RectTransform rect = content.GetComponent<RectTransform>();
      rect.pivot = new Vector2(0, 1);
      rect.offsetMin = new Vector2(0, StartYPos + AssetManager.culture_tech.list.Count * YStep);
      rect.offsetMax = new Vector2(0, StartYPos);
      int index = 0;
      foreach (CultureTechAsset tech in AssetManager.culture_tech.list) {
        LoadTechButton(selectedCulture, tech, content.transform, index++, button => {
          if (!selectedCulture.hasTech(tech.id)) {
            selectedCulture.addFinishedTech(tech.id);
          } else {
            selectedCulture.data.list_tech_ids.Remove(tech.id);
            selectedCulture.setDirty();
          }
        });
      }
      Window.clickShow();
    }
    
    private void LoadTechButton(Culture culture, CultureTechAsset tech, Transform parent, int index, Action<SwitchButton> callback) {
      SwitchButton techButton = UnityEngine.Object.Instantiate(SwitchButton.Prefab, parent);
      techButton.name = $"{tech.id} TechButtonToggle";
      techButton.transform.localPosition = new Vector3(StartXPos, StartYPos + YStep * index + 10.0f, techButton.transform.localPosition.z);
      try {
        techButton.Setup(culture.hasTech(tech.id), () => callback(techButton));
      } catch (Exception e) {
        Debug.LogWarning("Failed to load button for tech " + tech.id + ", it might show up in an unintended way. Error that caused this:\n\n" + e);
      }
      GameObject buttonLabel = new GameObject($"{tech.id} TechButtonLabel", typeof(Text));
      buttonLabel.GetComponent<Text>().text = LM.Get($"tech_{tech.id}");
      buttonLabel.GetComponent<Text>().font = techButton.GetComponentInChildren<Text>().font;
      buttonLabel.GetComponent<Text>().fontSize = Screen.height / 40;
      buttonLabel.GetComponent<Text>().alignment = TextAnchor.MiddleRight;
      buttonLabel.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonLabel.GetComponent<RectTransform>().sizeDelta.x + Screen.width / 7.5f, buttonLabel.GetComponent<RectTransform>().sizeDelta.y);
      GameObject buttonImage = new GameObject($"{tech.id} TechButtonImage", typeof(Image));
      buttonImage.GetComponent<Image>().sprite = SpriteTextureLoader.getSprite("ui/Icons/" + tech.path_icon);
      buttonImage.transform.SetParent(parent);
      buttonLabel.transform.SetParent(parent);
      techButton.transform.SetParent(parent);
      buttonImage.transform.localPosition = new Vector3(techButton.transform.localPosition.x + 35.0f, techButton.transform.localPosition.y + 0.0f, buttonImage.transform.localPosition.z);
      buttonLabel.transform.localPosition = new Vector3(techButton.transform.localPosition.x + 120.0f, techButton.transform.localPosition.y + 0.0f, buttonLabel.transform.localPosition.z);
    }
  }
}
