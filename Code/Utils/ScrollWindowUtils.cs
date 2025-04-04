using UnityEngine;
namespace PowerBox.Code.Utils {
  public static class ScrollWindowUtils {
    public static GameObject GetContentGameObject(this ScrollWindow window) {
      return window.transform
        .FindRecursive("Background")
        .FindRecursive("Scroll View")
        .FindRecursive("Viewport")
        .FindRecursive("Content")
        .gameObject;
    }
  }
}
