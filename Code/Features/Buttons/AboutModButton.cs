using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.Windows;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class AboutModButton : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(AboutPowerboxWindow) }).ToList();
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