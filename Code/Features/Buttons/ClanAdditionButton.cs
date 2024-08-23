using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class ClanAdditionButton : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(ClanAdditionPower) }).ToList();
    internal override FeatureRequirementList OptionalFeatures => new List<Type>{ typeof(ClanCreationButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "addToClan",
        Resources.Load<Sprite>("ui/icons/iconclanzones"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}
