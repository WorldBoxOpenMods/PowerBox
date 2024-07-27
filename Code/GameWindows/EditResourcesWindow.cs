using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using NeoModLoader.General;
using PowerBox.Code.Utils;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace PowerBox.Code.GameWindows {

  internal class EditResourcesWindow : WindowBase {
    private static ScrollWindow _editResourcesWindow;
    public EditResourcesWindow(Transform inspectVillageContent) {

      _editResourcesWindow = WindowCreator.CreateEmptyWindow("editResources", "edit_resources");
      _editResourcesWindow.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("edit_resources");
      _editResourcesWindow.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;

      GameObject editResources = Tab.CreateClickButton(
        "EditResources",
        AssetUtils.LoadEmbeddedSprite("powers/res_clear"),
        inspectVillageContent,
        EditResourcesButtonClick
      );


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
    public static void EditResourcesButtonClick() {
      _editResourcesWindow.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);
      Windows.EditResourcesWindow.InitEditResources();
      _editResourcesWindow.clickShow();
    }

    private void InitEditResources() {
      RectTransform rt = SpriteHighlighter.GetComponent<RectTransform>();

      rt.sizeDelta = new Vector2(60f, 60f);

      GameObject content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/" + _editResourcesWindow.name + "/Background/Scroll View/Viewport/Content");

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

      ResetWrapValues();
    }

    private static void LoadResourceButton(ResourceAsset asset, ButtonResource resourceButtonPref, Transform parent) {
      ButtonResource resourceButton = Object.Instantiate(resourceButtonPref, parent);

      CityData data = Config.selectedCity.data;
      resourceButton.load(asset, data.storage.get(asset.id));
      resourceButton.transform.Find("Text").gameObject.SetActive(false);
      resourceButton.transform.localPosition = Vector3.zero;

      GameObject nameInputElement = Object.Instantiate(GameObject.Find("NameInputElement"), parent);
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