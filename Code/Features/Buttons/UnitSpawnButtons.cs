using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.GodPowers;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class UnitSpawnButtons : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(UnitSpawnPowers) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(DebugMenuButton) };
    internal override bool Init() {
      Tab.CreateGodPowerButton(
        "spawnMaximCreature",
        Resources.Load<Sprite>("ui/icons/iconMaximCreature"),
        Tab.PowerboxTabObject.transform
      );
      Tab.CreateGodPowerButton(
        "spawnMastefCreature",
        Resources.Load<Sprite>("ui/icons/iconMastefCreature"),
        Tab.PowerboxTabObject.transform
      );
      Tab.CreateGodPowerButton(
        "spawnBurgerSpider",
        Resources.Load<Sprite>("ui/icons/iconburgerSpider"),
        Tab.PowerboxTabObject.transform
      );
      Tab.CreateGodPowerButton(
        "spawnGregCreature",
        Resources.Load<Sprite>("ui/icons/icongreg"),
        Tab.PowerboxTabObject.transform
      );
      Tab.CreateGodPowerButton(
        "spawnTumorCreatureUnit",
        Resources.Load<Sprite>("powers/tumor_unit_icon"),
        Tab.PowerboxTabObject.transform
      );
      Tab.CreateGodPowerButton(
        "spawnTumorCreatureAnimal",
        Resources.Load<Sprite>("powers/tumor_animal_icon"),
        Tab.PowerboxTabObject.transform
      );
      Tab.CreateGodPowerButton(
        "spawnMushCreatureUnit",
        Resources.Load<Sprite>("powers/mush_unit_icon"),
        Tab.PowerboxTabObject.transform
      );
      Tab.CreateGodPowerButton(
        "spawnMushCreatureAnimal",
        Resources.Load<Sprite>("powers/mush_animal_icon"),
        Tab.PowerboxTabObject.transform
      );
      return true;
    }
  }
}