using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerBox.Code.Buttons {
  public class ColonyCreationButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(GodPowers.ColonyCreationPower) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(CultureAdditionButton) };
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