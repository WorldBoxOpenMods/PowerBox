using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.NameGenerators {
  public class BurgerSpider : AssetFeature<NameGeneratorAsset> {
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
