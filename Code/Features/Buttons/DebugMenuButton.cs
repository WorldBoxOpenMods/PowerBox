using System.Linq;
using NeoModLoader.General;
using NeoModLoader.api;
using NeoModLoader.api.features;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Buttons {
  public class DebugMenuButton : ModButtonFeature<Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(AboutModButton);
    public override bool Init() {
      if (!base.Init()) return false;
      if (TryGetFeature<AboutModButton>(out _)) GetFeature<Tab>().AddHorizontalPadding(9.0f);
      return true;
    }

    protected override PowerButton InitObject() {
      PowerButton debugButton = PowerButtonCreator.CreateSimpleButton(
        "powerbox_debug_button",
        DebugButtonClick,
        Resources.Load<Sprite>("ui/icons/icondebug"),
        GetFeature<Tab>().PowerboxTabObject.transform
      );
      return debugButton;
    }

    private static void DebugButtonClick() {
      ResourcesFinder.FindResources<GameObject>("DebugButton").FirstOrDefault()?.GetComponent<Button>().onClick.Invoke();
    }
  }
}
