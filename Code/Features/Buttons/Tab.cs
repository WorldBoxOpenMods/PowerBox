using NeoModLoader.General.UI.Tab;
using NeoModLoader.api.features;
using PowerBox.Code.Utils;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class Tab : ModPowerTabFeature {
    private int _createdButtons;
    private const float StartX = 72f;
    private const float PlusX = 18f;
    private const float EvenY = 18f;
    private const float OddY = -18f;

    protected override PowersTab InitObject() {
      return TabManager.CreateTab("PowerBox", "powerbox_tab", "powerbox_tab_desc", AssetUtils.LoadEmbeddedSprite("powers/tabIcon"));
    }
    public override bool PositionButton(PowerButton button) {
      float x = StartX + (_createdButtons != 0 ? PlusX * (_createdButtons % 2 == 0 ? _createdButtons : _createdButtons - 1) : 0);
      float y = _createdButtons % 2 == 0 ? EvenY : OddY;
      button.transform.localPosition = new Vector3(x, y);
      _createdButtons++;
      return true;
    }
  }
}
