using NeoModLoader.api.features;
using UnityEngine;

namespace PowerBox.Code.Features.Prefabs {
  public class UnitAvatarElement : ModObjectFeature<GameObject> {
    public GameObject Prefab => Object;
    protected override GameObject InitObject() {
      return GameObject.Find("/Canvas Container Main").transform
        .FindRecursive("Canvas - UI/General")
        .FindRecursive("CanvasBottom")
        .FindRecursive("BottomElements")
        .FindRecursive("BottomElementsMover")
        .FindRecursive("CanvasScrollView")
        .FindRecursive("Scroll View")
        .FindRecursive("Viewport")
        .FindRecursive("Content")
        .FindRecursive("buttons")
        .FindRecursive("selected_unit")
        .FindRecursive("element_actor_info")
        .FindRecursive("UnitAvatarElement")
        .gameObject;
    }
  }
}
