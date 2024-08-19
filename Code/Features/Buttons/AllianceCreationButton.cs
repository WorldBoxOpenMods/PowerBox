using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class AllianceCreationButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(AllianceCreationPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(BurgerSpiderCloudSpawnButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "create_alliance",
        Resources.Load<Sprite>("ui/icons/iconalliance"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}