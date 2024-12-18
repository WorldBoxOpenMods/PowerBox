﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using NeoModLoader.General;
using PowerBox.Code.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Windows {

  internal class EditResourcesWindow : WindowBase<EditResourcesWindow> {
    protected override ScrollWindow InitObject() {
      ScrollWindow.checkWindowExist("village");
      GameObject inspectVillage = ResourcesFinder.FindResource<GameObject>("village");
      inspectVillage.SetActive(false);
      Transform inspectVillageBackground = inspectVillage.transform.Find("Background");
      ScrollWindow window = WindowCreator.CreateEmptyWindow("powerbox_edit_resources", "powerbox_edit_resources");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("powerbox_edit_resources");
      window.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;
      GameObject editResources = PowerButtonCreator.CreateSimpleButton("powerbox_edit_resources_button", EditResourcesButtonClick, AssetUtils.LoadEmbeddedSprite("powers/res_clear"), inspectVillageBackground).gameObject;
      editResources.transform.localPosition = new Vector3(116.50f, 3.0f, editResources.transform.localPosition.z);
      Transform editResourcesBtnIcon = editResources.transform.Find("Icon");
      editResourcesBtnIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(28f, 28f);
      editResourcesBtnIcon.transform.localScale = new Vector3(0.8f, 0.8f, 1);
      RectTransform editResourcesRect = editResources.GetComponent<RectTransform>();
      editResourcesRect.sizeDelta = new Vector2(32f, 36f);
      editResources.GetComponent<Image>().sprite = AssetUtils.LoadEmbeddedSprite("other/backgroundBackButtonRev");
      editResources.GetComponent<Button>().transition = Selectable.Transition.None;
      new Harmony("key.worldbox.powerbox").Patch(
        AccessTools.Method(typeof(CityWindow), nameof(CityWindow.OnDisable)),
        null,
        null,
        new HarmonyMethod(AccessTools.Method(typeof(EditResourcesWindow), nameof(StopOnDisableFromSettingSelectedCityToNull)))
      );
      return window;
    }
    
    private static IEnumerable<CodeInstruction> StopOnDisableFromSettingSelectedCityToNull(IEnumerable<CodeInstruction> instructions) {
      bool foundNullSet = false;
      foreach (CodeInstruction instruction in instructions) {
        if (instruction.opcode == OpCodes.Ldnull) {
          foundNullSet = true;
          continue;
        }
        if (foundNullSet && instruction.opcode == OpCodes.Stsfld && (FieldInfo)instruction.operand == typeof(Config).GetField(nameof(Config.selectedCity))) {
          continue;
        }
        foundNullSet = false;
        yield return instruction;
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

      GameObject content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/" + Window.name + "/Background/Scroll View/Viewport/Content");

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

      CityData data = Config.selectedCity.data;
      resourceButton.load(asset, data.storage.get(asset.id));
      resourceButton.transform.Find("Text").gameObject.SetActive(false);
      resourceButton.transform.localPosition = Vector3.zero;

      GameObject nameInputElement = UnityEngine.Object.Instantiate(GameObject.Find("NameInputElement"), parent);
      nameInputElement.transform.localPosition = new Vector2(50f, 0);
      nameInputElement.transform.localScale = new Vector2(0.75f, 0.75f);
      NameInput inputComponent = nameInputElement.GetComponent<NameInput>();
      inputComponent.setText(data.storage.get(asset.id).ToString());

      inputComponent.inputField.onEndEdit.AddListener(param1 => CheckInput(inputComponent, asset, data));
    }

    private static void CheckInput(NameInput text, Asset asset, CityData cityData) {
      if (int.TryParse(text.textField.text, out int number)) {
        cityData.storage.set(asset.id, Mathf.Clamp(number, 0, 999));
      }
      text.setText(cityData.storage.get(asset.id).ToString());
    }
  }
}
