using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.NameGenerators {
  public class BurgerSpider : ModAssetFeature<NameGeneratorAsset> {
    protected override NameGeneratorAsset InitObject() {
      NameGeneratorAsset burgerSpiderName = new NameGeneratorAsset {
        id = "powerbox_burger_spider_name"
      };
      burgerSpiderName.addPartGroup("Burger,Spider");
      burgerSpiderName.addPartGroup("-");
      burgerSpiderName.addPartGroup("spider,burger");
      burgerSpiderName.addTemplate("part_group");
      return burgerSpiderName;
    }
  }
}
