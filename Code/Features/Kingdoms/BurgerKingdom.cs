using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Kingdoms {
  public class BurgerKingdom : AssetFeature<KingdomAsset> {
    protected override KingdomAsset InitObject() {
      KingdomAsset burgerKingdom = new KingdomAsset {
        id = "powerbox_burger_kingdom",
        mobs = true,
        default_kingdom_color = AssetManager.kingdom_colors_library.getNextColor()
      };
      burgerKingdom.addTag(burgerKingdom.id);
      burgerKingdom.addTag("nature_creature");
      burgerKingdom.addFriendlyTag("nature_creature");
      burgerKingdom.addFriendlyTag("neutral");
      burgerKingdom.addEnemyTag("civ");
      burgerKingdom.addEnemyTag("bandits");
      burgerKingdom.addEnemyTag("powerbox_developer_kingdom");

      MapBox.instance.kingdoms_wild.newWildKingdom(burgerKingdom);

      KingdomAsset human = AssetManager.kingdoms.get("human");
      human.addEnemyTag(burgerKingdom.id);
      KingdomAsset elf = AssetManager.kingdoms.get("elf");
      elf.addEnemyTag(burgerKingdom.id);
      KingdomAsset dwarf = AssetManager.kingdoms.get("dwarf");
      dwarf.addEnemyTag(burgerKingdom.id);
      KingdomAsset orc = AssetManager.kingdoms.get("orc");
      orc.addEnemyTag(burgerKingdom.id);
      KingdomAsset bandit = AssetManager.kingdoms.get("bandits");
      bandit.addEnemyTag(burgerKingdom.id);
      return burgerKingdom;
    }
  }
}
