using System.Collections.Generic;

namespace PowerBox.Code {
  internal static class Actors {
    internal static void Init() {
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
      
      NameGeneratorAsset burgerSpiderName = new NameGeneratorAsset {
        id = "burger_spider_name"
      };
      burgerSpiderName.part_groups.Add("Burger,Spider");
      burgerSpiderName.part_groups.Add("-");
      burgerSpiderName.part_groups.Add("spider,burger");
      burgerSpiderName.templates.Add("part_group");
      AssetManager.nameGenerator.add(burgerSpiderName);


      KingdomAsset burgerKingdom = new KingdomAsset {
        id = "burgers",
        mobs = true,
        default_kingdom_color = AssetManager.kingdom_colors_library.getNextColor()
      };
      burgerKingdom.addTag("burgers");
      burgerKingdom.addTag("nature_creature");
      burgerKingdom.addFriendlyTag("nature_creature");
      burgerKingdom.addFriendlyTag("neutral");
      burgerKingdom.addEnemyTag("civ");
      burgerKingdom.addEnemyTag("bandits");
      burgerKingdom.addEnemyTag("developers");
      AssetManager.kingdoms.add(burgerKingdom);

      MapBox.instance.kingdoms.newHiddenKingdom(burgerKingdom);

      KingdomAsset human = AssetManager.kingdoms.get("human");
      human.addEnemyTag("burgers");
      human.addFriendlyTag("developers");
      KingdomAsset elf = AssetManager.kingdoms.get("elf");
      elf.addEnemyTag("burgers");
      elf.addFriendlyTag("developers");
      KingdomAsset dwarf = AssetManager.kingdoms.get("dwarf");
      dwarf.addEnemyTag("burgers");
      dwarf.addFriendlyTag("developers");
      KingdomAsset orc = AssetManager.kingdoms.get("orc");
      orc.addEnemyTag("burgers");
      orc.addFriendlyTag("developers");
      KingdomAsset bandit = AssetManager.kingdoms.get("bandits");
      bandit.addEnemyTag("burgers");
      bandit.addFriendlyTag("developers");


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
      
      NameGeneratorAsset maximCreatureName = new NameGeneratorAsset {
        id = "maxim_creature_name"
      };
      maximCreatureName.part_groups.Add("Maxim,Max,Greg,dev");
      maximCreatureName.part_groups.Add(" ");
      maximCreatureName.part_groups.Add("Karpenko,dev,greg");
      maximCreatureName.templates.Add("part_group");
      AssetManager.nameGenerator.add(maximCreatureName);

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
      
      NameGeneratorAsset mastefCreatureName = new NameGeneratorAsset {
        id = "mastef_creature_name"
      };
      mastefCreatureName.part_groups.Add("Mastef,Markus,Big Lebovski,Greg,dev");
      mastefCreatureName.part_groups.Add(" ");
      mastefCreatureName.part_groups.Add("Stefanko,dev,greg");
      mastefCreatureName.templates.Add("part_group");
      AssetManager.nameGenerator.add(mastefCreatureName);

      KingdomAsset developersKingdom = new KingdomAsset {
        id = "developers",
        mobs = true,
        default_kingdom_color = AssetManager.kingdom_colors_library.getNextColor()
      };
      developersKingdom.addTag("developers");
      developersKingdom.addTag("good");
      developersKingdom.addFriendlyTag("neutral");
      developersKingdom.addFriendlyTag("civ");
      developersKingdom.addEnemyTag("burgers");
      AssetManager.kingdoms.add(developersKingdom);


      MapBox.instance.kingdoms.newHiddenKingdom(developersKingdom);
    }
  }
}