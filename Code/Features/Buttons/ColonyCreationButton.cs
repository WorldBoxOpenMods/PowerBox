using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class ColonyCreationButton : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(ColonyCreationPower) }).ToList();
    internal override FeatureRequirementList OptionalFeatures => new List<Type>{ typeof(CultureAdditionButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "makeColony",
        Resources.Load<Sprite>("powers/colonies"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}