using System.Linq;
using NeoModLoader.General;
using NeoModLoader.api;
using NeoModLoader.api.features;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Buttons {
  public class DebugMenuButton : ModButtonFeature<Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(AboutModButton);

    protected override PowerButton InitObject() {
      PowerButton debugButton = PowerButtonCreator.CreateSimpleButton(
        "powerbox_debug_button",
        DebugButtonClick,
        Resources.Load<Sprite>("ui/icons/icondebug"),
        GetFeature<Tab>().Object.transform
      );
      return debugButton;
    }

    private static void DebugButtonClick() {
      ResourcesFinder.FindResources<GameObject>("DebugButton").FirstOrDefault()?.GetComponent<Button>().onClick.Invoke();
    }
  }
}
