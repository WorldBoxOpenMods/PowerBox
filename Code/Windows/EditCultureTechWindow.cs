using System;
using NeoModLoader.General;
using NeoModLoader.General.UI.Prefabs;
using PowerBox.Code.Utils;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace PowerBox.Code.Windows {
  public class EditCultureTechWindow : WindowBase<EditCultureTechWindow> {
    private ScrollWindow _editCultureTechWindow;
    internal override bool Init() {
      if (!base.Init()) return false;
      ScrollWindow.checkWindowExist("culture");
      GameObject cultureObject = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/culture");
      Transform cultureContent = cultureObject.transform.Find("/Canvas Container Main/Canvas - Windows/windows/culture/Background");
      cultureObject.SetActive(false);
      Init(cultureContent);
      return true;
    }
    private void Init(Transform inspectCultureContent) {
      _editCultureTechWindow = WindowCreator.CreateEmptyWindow("edit_culture_tech", "edit_culture_tech");
      _editCultureTechWindow.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("edit_culture_tech");
      _editCultureTechWindow.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;

      _editCultureTechWindow.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);

      GameObject editItems = PowerButtonCreator.CreateSimpleButton(
        "EditCultureTech",
        EditCultureTechButtonClick,
        AssetUtils.LoadEmbeddedSprite("powers/items"),
        inspectCultureContent
      ).gameObject;

      GameObject viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{_editCultureTechWindow.name}/Background/Scroll View/Viewport");
      RectTransform viewportRect = viewport.GetComponent<RectTransform>();
      viewportRect.sizeDelta = new Vector2(0, 17);


      editItems.transform.localPosition = new Vector3(116.5f, 0.8f, editItems.transform.localPosition.z);

      Transform editItemsBtnIcon = editItems.transform.Find("Icon");
      editItemsBtnIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(28f, 28f);
      editItemsBtnIcon.transform.localScale = new Vector3(0.8f, 0.8f, 1);

      RectTransform editItemsRect = editItems.GetComponent<RectTransform>();
      editItemsRect.sizeDelta = new Vector2(32f, 36f);
      editItems.GetComponent<Image>().sprite = AssetUtils.LoadEmbeddedSprite("other/backgroundBackButtonRev");
      editItems.GetComponent<Button>().transition = Selectable.Transition.None;
    }

    private void EditCultureTechButtonClick() {
      Culture selectedCulture = Config.selectedCulture;
      if (selectedCulture == null) {
        WorldTip.showNow("no_culture_selected_error", true, "top");
        return;
      }
      GameObject content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/" + _editCultureTechWindow.name + "/Background/Scroll View/Viewport/Content");
      _editCultureTechWindow.resetScroll();
      for (int i = 0; i < content.transform.childCount; i++) {
        Object.Destroy(content.transform.GetChild(i).gameObject);
      }
      int index = 0;
      foreach (CultureTechAsset tech in AssetManager.culture_tech.list) {
        LoadTechButton(selectedCulture, tech, content.transform, index++, (button) => {
          if (!selectedCulture.hasTech(tech.id)) {
            selectedCulture.addFinishedTech(tech.id);
          } else {
            selectedCulture.data.list_tech_ids.Remove(tech.id);
            selectedCulture.setDirty();
          }
        });
      }
      _editCultureTechWindow.clickShow();
    }
    
    private void LoadTechButton(Culture culture, CultureTechAsset tech, Transform parent, int index, Action<SwitchButton> callback) {
      parent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, index * 15);
      SwitchButton techButton = Object.Instantiate(SwitchButton.Prefab, parent);
      techButton.transform.localPosition = new Vector3(60, StartYPos * AssetManager.culture_tech.list.Count + index * 15, 0);
      try {
        techButton.Setup(culture.hasTech(tech.id), () => callback(techButton));
      } catch (Exception e) {
        Debug.LogWarning("Failed to load button for tech " + tech.id + ", it might show up in an unintended way. Error that caused this:\n\n" + e);
      }
      GameObject buttonLabel = new GameObject("TechButtonLabel", typeof(Text));
      buttonLabel.GetComponent<Text>().text = tech.id;
      GameObject buttonImage = new GameObject("TechButtonImage", typeof(Image));
      buttonImage.GetComponent<Image>().sprite = SpriteTextureLoader.getSprite("ui/Icons/" + tech.path_icon);
      buttonImage.transform.SetParent(techButton.transform);
      buttonLabel.transform.SetParent(techButton.transform);
      techButton.transform.SetParent(parent);
    }
  }
}