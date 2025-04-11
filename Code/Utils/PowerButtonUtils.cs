using NeoModLoader.General;
using UnityEngine;
using UnityEngine.Events;

namespace PowerBox.Code.Utils {
  public static class PowerButtonUtils {
    public static PowerButton CreateButton(string name, Sprite sprite, Transform parent, UnityAction call) {
      if (call != null) {
        return PowerButtonCreator.CreateSimpleButton(name, call, sprite, parent);
      } else {
        return PowerButtonCreator.CreateGodPowerButton(name, sprite, parent);
      }
    }
  }
}
