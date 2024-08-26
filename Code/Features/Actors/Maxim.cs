using System.Collections.Generic;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Actors {
  public class Maxim : AssetFeature<ActorAsset> {
    internal override FeatureRequirementList RequiredFeatures => new[] { typeof(Kingdoms.Developers), typeof(NameGenerators.Maxim) };
    protected override bool AddToLibrary => false;
    protected override ActorAsset InitObject() {
      ActorAsset maximCreature = AssetManager.actor_library.clone("powerbox_maxim", "whiteMage");
      maximCreature.base_stats[S.max_age] = 1000;
      maximCreature.icon = "iconMaximCreature";
      maximCreature.race = "good";
      maximCreature.kingdom = GetFeature<Kingdoms.Developers>().Object.id;
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
      maximCreature.nameTemplate = GetFeature<NameGenerators.Maxim>().Object.id;
      return maximCreature;
    }
  }
}
