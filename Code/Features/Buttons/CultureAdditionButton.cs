using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class CultureAdditionButton : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(CultureAdditionPower) }).ToList();
    internal override FeatureRequirementList OptionalFeatures => new List<Type>{ typeof(CultureDuplicationButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "addToCulture",
        Resources.Load<Sprite>("ui/icons/iconculturezones"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}