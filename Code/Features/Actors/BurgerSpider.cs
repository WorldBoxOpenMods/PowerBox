using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Actors {
  public class BurgerSpider : AssetFeature<ActorAsset> {
    internal override FeatureRequirementList RequiredFeatures => new[] { typeof(NameGenerators.BurgerSpider), typeof(Kingdoms.BurgerKingdom) };
    protected override bool AddToLibrary => false;
    protected override ActorAsset InitObject() {
      ActorAsset burgerSpider = AssetManager.actor_library.clone("powerbox_burger_spider", "wolf");
      burgerSpider.icon = "iconBurgerSpider";
      burgerSpider.base_stats[S.max_age] = 250;
      burgerSpider.race = burgerSpider.id;
      burgerSpider.kingdom = GetFeature<Kingdoms.BurgerKingdom>().Object.id;
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
      burgerSpider.nameTemplate = GetFeature<NameGenerators.BurgerSpider>().Object.id;
      return burgerSpider;
    }
  }
}
