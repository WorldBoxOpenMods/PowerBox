using System;
using System.Collections.Generic;
using System.Linq;
using NeoModLoader.General;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace PowerBox.Code.Features.Buttons {
  public class DebugMenuButton : ButtonFeature {
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(AboutModButton) };
    internal override bool Init() {
      GameObject dbgBtn = Tab.CreateClickButton(
        "DebugButtonAdd",
        Resources.Load<Sprite>("ui/icons/icondebug"),
        Tab.PowerboxTabObject.transform,
        DebugButtonAddClick
      );
      if (TryGetFeature<AboutModButton>(out _)) Tab.AddHorizontalPadding(9.0f);
      Object.Destroy(dbgBtn.transform.GetComponent<DebugButton>());
      return true;
    }
    
    private static void DebugButtonAddClick() {
      ResourcesFinder.FindResources<GameObject>("DebugButton").FirstOrDefault()?.GetComponent<Button>().onClick.Invoke();
    }
  }
}