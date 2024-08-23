using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class AssignKingButton : ButtonFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures.Concat(new List<Type> {
      typeof(GodPowers.AssignKingPower)
    }).ToList();
    internal override FeatureRequirementList OptionalFeatures => new List<Type>{ typeof(ColonyCreationButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "assign_king",
        Resources.Load<Sprite>("ui/icons/iconkings"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}