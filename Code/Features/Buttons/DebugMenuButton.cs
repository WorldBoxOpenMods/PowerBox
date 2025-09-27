using System.Linq;
using NeoModLoader.api;
using NeoModLoader.General;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Buttons {
  public class DebugMenuButton : PowerboxButtonFeature {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(AboutModButton);

    protected override TabSection Section => TabSection.All;

    protected override PowerButton InitObject() {
      PowerButton debugButton = PowerButtonCreator.CreateSimpleButton(
        "powerbox_debug_button",
        DebugButtonClick,
        Resources.Load<Sprite>("ui/icons/icondebug"),
        GetFeature<PowerboxTab>().Object.transform
      );
      return debugButton;
    }

    private static void DebugButtonClick() {
      ResourcesFinder.FindResources<GameObject>("DebugButton").FirstOrDefault()?.GetComponent<Button>().onClick.Invoke();
    }
  }
}
