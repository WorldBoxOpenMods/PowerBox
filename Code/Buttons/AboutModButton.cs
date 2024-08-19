using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Buttons {
  public class AboutModButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(Windows.AboutPowerboxWindow) }).ToList();
    internal override bool Init() {
      Tab.CreateClickButton(
        "AboutMod",
        Resources.Load<Sprite>("ui/icons/iconabout"),
        Tab.PowerboxTabObject.transform,
        AboutModButtonClick
      );
      return true;
    }
    private static void AboutModButtonClick() {
      ScrollWindow.showWindow("aboutPowerBox");
    }
  }
}