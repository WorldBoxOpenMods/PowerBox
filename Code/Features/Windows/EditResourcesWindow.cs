using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using NeoModLoader.api;
using NeoModLoader.General;
using PowerBox.Code.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Windows {

  internal class EditResourcesWindow : WindowBase<EditResourcesWindow> {
    public override ModFeatureRequirementList RequiredModFeatures => base.RequiredModFeatures + typeof(Harmony);

    protected override ScrollWindow InitObject() {
      ScrollWindow window = WindowCreator.CreateEmptyWindow("powerbox_edit_resources", "powerbox_edit_resources", "res_clear");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("powerbox_edit_resources");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;
      GetFeature<Harmony>().Instance.Patch(
        AccessTools.Method(typeof(StatsWindow), nameof(StatsWindow.create)),
        postfix: new HarmonyMethod(typeof(EditResourcesWindow), nameof(HookUpMembersWindow))
      );
      return window;
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    private static void HookUpMembersWindow(StatsWindow __instance) {
      if (__instance is CityWindow cityWindow) {
        Transform cityWindowContent = cityWindow.transform.FindRecursive("Background");
        GameObject editResources = PowerButtonCreator.CreateSimpleButton("powerbox_edit_resources_button", Instance.EditResourcesButtonClick, Resources.Load<Sprite>("ui/icons/res_clear"), cityWindowContent).gameObject;
        editResources.transform.localPosition = new Vector3(116.50f, 3.0f, editResources.transform.localPosition.z);
        Transform editResourcesBtnIcon = editResources.transform.Find("Icon");
        editResourcesBtnIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(28f, 28f);
        editResourcesBtnIcon.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        RectTransform editResourcesRect = editResources.GetComponent<RectTransform>();
        editResourcesRect.sizeDelta = new Vector2(32f, 36f);
        editResources.GetComponent<Image>().sprite = AssetUtils.LoadEmbeddedSprite("other/backgroundBackButtonRev");
        editResources.GetComponent<Button>().transition = Selectable.Transition.None;
        Instance.GetFeature<Harmony>().Instance.Unpatch(
          AccessTools.Method(typeof(StatsWindow), nameof(StatsWindow.create)),
          AccessTools.Method(typeof(EditResourcesWindow), nameof(HookUpMembersWindow))
        );
      }
    }

    public void EditResourcesButtonClick() {
      Window.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);
      InitEditResources();
      Window.clickShow();
    }

    private void InitEditResources() {
      RectTransform rt = SpriteHighlighter.GetComponent<RectTransform>();

      rt.sizeDelta = new Vector2(60f, 60f);

      GameObject content = Window.GetContentGameObject();

      List<ResourceAsset> resourceArray = AssetManager.resources.dict.Values.ToList();


      content.transform.DetachChildren();

      ButtonResource resourceButton = ResourcesFinder.FindResource<GameObject>("ResourceElement").GetComponent<ButtonResource>();

      StartXPos = 40.4f;
      XStep = 99f;
      YStep = -20f;
      CountInRow = 2;


      RectTransform rect = content.GetComponent<RectTransform>();
      rect.pivot = new Vector2(0, 1);
      rect.sizeDelta = new Vector2(0, Mathf.Abs(GetPosByIndex(resourceArray.Count).y) + 100);

      for (int i = 0; i < resourceArray.Count; i++) {
        GameObject hl = AddHighLight(i, content);

        LoadResourceButton(resourceArray[i], resourceButton, hl.transform);
      }

      StartXPos = 40f;
      XStep = 22f;
      CountInRow = 9;
      StartYPos = -22.5f;
      YStep = -22.5f;
    }

    private static void LoadResourceButton(ResourceAsset asset, ButtonResource resourceButtonPref, Transform parent) {
      ButtonResource resourceButton = UnityEngine.Object.Instantiate(resourceButtonPref, parent);

      List<Building> storages = SelectedMetas.selected_city.storages.Where(s => s.isUsable()).ToList();

      resourceButton.load(asset, storages.Select(s => s.resources.get(asset.id)).Sum());
      resourceButton.transform.Find("Text").gameObject.SetActive(false);
      resourceButton.transform.localPosition = Vector3.zero;

      GameObject nameInputElement = UnityEngine.Object.Instantiate(GameObject.Find("NameInputElement"), parent);
      nameInputElement.transform.localPosition = new Vector2(50f, 0);
      nameInputElement.transform.localScale = new Vector2(0.75f, 0.75f);
      NameInput inputComponent = nameInputElement.GetComponent<NameInput>();
      inputComponent.setText(storages.Select(s => s.resources.get(asset.id)).Sum().ToString());

      inputComponent.inputField.onEndEdit.AddListener(param1 => CheckInput(inputComponent, asset, storages));
    }

    private static void CheckInput(NameInput text, Asset asset, List<Building> storages) {
      if (storages.Count == 0) {
        WorldTip.showNow("powerbox_edit_resources_no_storage_error", true, "top");
        return;
      }
      if (int.TryParse(text.textField.text, out int number)) {
        storages.First().resources.set(asset.id, Mathf.Clamp(number, 0, 999));
        foreach (Building storage in storages.Skip(1)) {
          storage.resources.set(asset.id, 0);
        }
      }
      text.setText(storages.Select(s => s.resources.get(asset.id)).Sum().ToString());
    }
  }
}
