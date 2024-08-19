using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Kingdoms {
  public class Developers : Feature {
    internal override bool Init() {
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
      
      KingdomAsset human = AssetManager.kingdoms.get("human");
      human.addFriendlyTag("developers");
      KingdomAsset elf = AssetManager.kingdoms.get("elf");
      elf.addFriendlyTag("developers");
      KingdomAsset dwarf = AssetManager.kingdoms.get("dwarf");
      dwarf.addFriendlyTag("developers");
      KingdomAsset orc = AssetManager.kingdoms.get("orc");
      orc.addFriendlyTag("developers");
      KingdomAsset bandit = AssetManager.kingdoms.get("bandits");
      bandit.addFriendlyTag("developers");
      return true;
    }
  }
}