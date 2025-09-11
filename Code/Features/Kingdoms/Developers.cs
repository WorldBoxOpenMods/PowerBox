using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Kingdoms {
  public class Developers : ModAssetFeature<KingdomAsset> {
    protected override KingdomAsset InitObject() {
      KingdomAsset developersKingdom = new KingdomAsset {
        id = "powerbox_developer_kingdom",
        mobs = true,
        default_kingdom_color = AssetManager.kingdom_colors_library.getNextColor(null)
      };
      developersKingdom.addTag(developersKingdom.id);
      developersKingdom.addTag("good");
      developersKingdom.addFriendlyTag("neutral");
      developersKingdom.addFriendlyTag("civ");
      developersKingdom.addEnemyTag("powerbox_burger_kingdom");
      MapBox.instance.kingdoms_wild.newWildKingdom(developersKingdom);

      KingdomAsset human = AssetManager.kingdoms.get("human");
      human.addFriendlyTag(developersKingdom.id);
      KingdomAsset elf = AssetManager.kingdoms.get("elf");
      elf.addFriendlyTag(developersKingdom.id);
      KingdomAsset dwarf = AssetManager.kingdoms.get("dwarf");
      dwarf.addFriendlyTag(developersKingdom.id);
      KingdomAsset orc = AssetManager.kingdoms.get("orc");
      orc.addFriendlyTag(developersKingdom.id);
      KingdomAsset bandit = AssetManager.kingdoms.get("bandit");
      bandit.addFriendlyTag(developersKingdom.id);
      return developersKingdom;
    }
  }
}
