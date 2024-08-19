using JetBrains.Annotations;
using NeoModLoader.General;
using NeoModLoader.General.UI.Tab;
using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace PowerBox.Code.Features.Buttons {
  public class Tab : Feature {
    public GameObject PowerboxTabObject;
    public PowersTab PowerboxTab;

    private int _createdButtons;
    private const float StartX = 72f;
    private const float PlusX = 18f;
    private const float EvenY = 18f;
    private const float OddY = -18f;
    private float _horizontalPadding;
    
    internal override bool Init() {
      PowerboxTab = TabManager.CreateTab("PowerBox", "tab_additional", "tab_additional_desc", AssetUtils.LoadEmbeddedSprite("powers/tabIcon"));
      PowerboxTabObject = PowerboxTab.gameObject;
      return true;
    }

    public void AddHorizontalPadding(float padding) {
      _horizontalPadding += padding;
    }
    public GameObject CreateClickButton(string name, Sprite sprite, Transform parent, [NotNull] UnityAction call) {
      PowerButton newButton = PowerButtonCreator.CreateSimpleButton(name, call, sprite, parent);
      AlignButtonInTab(newButton);
      return newButton.gameObject;
    }

    public GameObject CreateGodPowerButton(string name, Sprite sprite, Transform parent) {
      PowerButton newButton = PowerButtonCreator.CreateGodPowerButton(name, sprite, parent);
      AlignButtonInTab(newButton);
      return newButton.gameObject;
    }

    public GameObject CreateWindowButton(string name, string windowName, Sprite sprite, Transform parent) {
      PowerButton newButton = PowerButtonCreator.CreateWindowButton(name, windowName, sprite, parent);
      AlignButtonInTab(newButton);
      return newButton.gameObject;
    }

    private void AlignButtonInTab(PowerButton newButton) {

      float x = StartX + (_createdButtons != 0 ? PlusX * (_createdButtons % 2 == 0 ? _createdButtons : _createdButtons - 1) : 0) + _horizontalPadding;
      float y = _createdButtons % 2 == 0 ? EvenY : OddY;
      newButton.transform.localPosition = new Vector3(x, y);
      _createdButtons++;
    }
  }
}