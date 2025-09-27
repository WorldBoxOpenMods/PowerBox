using NeoModLoader.api;
using NeoModLoader.api.features;
using strings;

namespace PowerBox.Code.Features.Actors {
  public class BurgerSpider : ModAssetFeature<ActorAsset> {
    public override ModFeatureRequirementList RequiredModFeatures => new[] {typeof(NameGenerators.BurgerSpider), typeof(Kingdoms.BurgerKingdom)};
    protected override bool AddToLibrary => false;
    protected override ActorAsset InitObject() {
      ActorAsset burgerSpider = AssetManager.actor_library.clone("powerbox_burger_spider", "wolf");
      burgerSpider.icon = "burger_spider";
      burgerSpider.name_locale = "powerbox_spawn_burger_spider";
      burgerSpider.base_stats[S.lifespan] = 250;
      burgerSpider.kingdom_id_wild = GetFeature<Kingdoms.BurgerKingdom>().Object.id;
      burgerSpider.civ = false;
      burgerSpider.default_animal = false;
      burgerSpider.has_advanced_textures = false;
      burgerSpider.unit_other = true;
      burgerSpider.shadow = false;
      burgerSpider.can_attack_buildings = true;
      burgerSpider.can_turn_into_zombie = false;
      burgerSpider.can_be_moved_by_powers = true;
      burgerSpider.can_be_killed_by_stuff = true;
      burgerSpider.can_receive_traits = true;
      burgerSpider.can_be_hurt_by_powers = true;
      burgerSpider.texture_id = "t_burgerSpider";
      burgerSpider.addSubspeciesTrait("diet_cannibalism");
      burgerSpider.use_items = false;
      burgerSpider.base_stats[S.damage] = 25;
      burgerSpider.traits.Add("regeneration");
      burgerSpider.traits.Add("ugly");
      burgerSpider.traits.Add("cursed");
      burgerSpider.name_template_unit = GetFeature<NameGenerators.BurgerSpider>().Object.id;
      burgerSpider.texture_asset = null;
      AssetManager.actor_library.loadTexturesAndSprites(burgerSpider);
      return burgerSpider;
    }
  }
}
