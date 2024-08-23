using System;
using System.Collections.Generic;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Actors {
  public class Developers : Feature {

    internal override FeatureRequirementList RequiredFeatures => new List<Type> { typeof(Kingdoms.Developers), typeof(NameGenerators.Developers) };

    internal override bool Init() {
      ActorAsset maximCreature = AssetManager.actor_library.clone("MaximCreature", "whiteMage");
      maximCreature.id = "MaximCreature";
      maximCreature.base_stats[S.max_age] = 1000;
      maximCreature.icon = "iconMaximCreature";
      maximCreature.race = "good";
      maximCreature.kingdom = "developers";
      maximCreature.unit = false;
      maximCreature.canAttackBuildings = false;
      maximCreature.canTurnIntoZombie = false;
      maximCreature.canBeMovedByPowers = true;
      maximCreature.canBeKilledByStuff = true;
      maximCreature.canReceiveTraits = true;
      maximCreature.canBeHurtByPowers = true;
      maximCreature.canAttackBuildings = false;
      maximCreature.shadow = false;
      maximCreature.texture_path = "t_MaximCreature";
      maximCreature.job = "white_mage";
      maximCreature.diet_meat_same_race = false;
      maximCreature.diet_meat = false;
      maximCreature.base_stats[S.damage] = 100;
      maximCreature.base_stats[S.health] = 1000;
      maximCreature.use_items = false;
      maximCreature.defaultWeapons = null;
      maximCreature.source_meat = false;
      maximCreature.source_meat_insect = false;
      maximCreature.traits = new List<string> {
        "immortal",
        "blessed",
        "wise"
      };
      maximCreature.nameTemplate = "maxim_creature_name";

      ActorAsset mastefCreature = AssetManager.actor_library.clone("MastefCreature", "MaximCreature");
      mastefCreature.id = "MastefCreature";
      mastefCreature.icon = "iconMastefCreature";
      mastefCreature.texture_path = "t_MastefCreature";
      mastefCreature.unit = false;
      mastefCreature.shadow = false;
      mastefCreature.traits = new List<string> {
        "immortal",
        "blessed",
        "fast"
      };
      mastefCreature.nameTemplate = "mastef_creature_name";

      return true;
    }
  }
}