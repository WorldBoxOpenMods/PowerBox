using System;
using System.Collections.Generic;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Actors {
  public class BurgerSpider : Feature {

    internal override List<Type> RequiredFeatures => new List<Type> { typeof(NameGenerators.BurgerSpider), typeof(Kingdoms.BurgerKingdom) };

    internal override bool Init() {
      ActorAsset burgerSpider = AssetManager.actor_library.clone("burgerSpider", "wolf");
      burgerSpider.id = "burgerSpider";
      burgerSpider.icon = "iconburgerSpider";
      burgerSpider.base_stats[S.max_age] = 250;
      burgerSpider.race = "burgerSpider";
      burgerSpider.kingdom = "burgers";
      burgerSpider.unit = false;
      burgerSpider.shadow = false;
      burgerSpider.canAttackBuildings = true;
      burgerSpider.canTurnIntoZombie = false;
      burgerSpider.canBeMovedByPowers = true;
      burgerSpider.canBeKilledByStuff = true;
      burgerSpider.canReceiveTraits = true;
      burgerSpider.canBeHurtByPowers = true;
      burgerSpider.texture_path = "t_burgerSpider";
      burgerSpider.icon = "iconWolf";
      burgerSpider.job = "animal_herd";
      burgerSpider.diet_meat_same_race = true;
      burgerSpider.diet_meat = true;
      burgerSpider.texture_heads = "";
      burgerSpider.use_items = false;
      burgerSpider.base_stats[S.damage] = 25;
      burgerSpider.traits.Add("regeneration");
      burgerSpider.traits.Add("ugly");
      burgerSpider.traits.Add("cursed");
      burgerSpider.nameTemplate = "burger_spider_name";
      return true;
    }
  }
}