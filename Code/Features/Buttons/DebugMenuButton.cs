using System.Linq;
using NeoModLoader.General;
using PowerBox.Code.LoadingSystem;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Buttons {
  public class DebugMenuButton : ButtonFeature<Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(AboutModButton);
    internal override bool Init() {
      if (!base.Init()) return false;
      if (TryGetFeature<AboutModButton>(out _)) GetFeature<Tab>().AddHorizontalPadding(9.0f);
      return true;
    }

    protected override PowerButton InitObject() {
      PowerButton debugButton = PowerButtonCreator.CreateSimpleButton(
        "DebugButton",
        DebugButtonAddClick,
        Resources.Load<Sprite>("ui/icons/icondebug"),
        GetFeature<Tab>().PowerboxTabObject.transform
      );
      UnityEngine.Object.Destroy(debugButton.transform.GetComponent<DebugButton>());
      return debugButton;
    }

    private static void DebugButtonAddClick() {
      ResourcesFinder.FindResources<GameObject>("DebugButton").FirstOrDefault()?.GetComponent<Button>().onClick.Invoke();
    }
  }
}
