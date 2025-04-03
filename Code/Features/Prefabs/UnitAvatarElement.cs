using NeoModLoader.api.features;
using UnityEngine;
namespace PowerBox.Code.Features.Prefabs {
  public class UnitAvatarElement : ModObjectFeature<GameObject> {
    public GameObject Prefab => Object;
    protected override GameObject InitObject() {
      return GameObject.Find("Canvas Container Main/Canvas - UI/General/CanvasBottom/BottomElements/BottomElementsMover/CanvasScrollView/Scroll View/Viewport/Content/buttons/Tab_SelectedUnit/actor_info/UnitAvatarElement");
    }
  }
}
