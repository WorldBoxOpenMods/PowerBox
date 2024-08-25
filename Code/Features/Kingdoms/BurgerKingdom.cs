using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Kingdoms {
  public class BurgerKingdom : AssetFeature<KingdomAsset> {
    protected override KingdomAsset InitObject() {
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

      MapBox.instance.kingdoms.newHiddenKingdom(burgerKingdom);

      KingdomAsset human = AssetManager.kingdoms.get("human");
      human.addEnemyTag("burgers");
      KingdomAsset elf = AssetManager.kingdoms.get("elf");
      elf.addEnemyTag("burgers");
      KingdomAsset dwarf = AssetManager.kingdoms.get("dwarf");
      dwarf.addEnemyTag("burgers");
      KingdomAsset orc = AssetManager.kingdoms.get("orc");
      orc.addEnemyTag("burgers");
      KingdomAsset bandit = AssetManager.kingdoms.get("bandits");
      bandit.addEnemyTag("burgers");
      return burgerKingdom;
    }
  }
}
