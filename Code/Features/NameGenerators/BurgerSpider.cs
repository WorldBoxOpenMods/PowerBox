using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.NameGenerators {
  public class BurgerSpider : AssetFeature<NameGeneratorAsset> {
    protected override NameGeneratorAsset InitObject() {
      NameGeneratorAsset burgerSpiderName = new NameGeneratorAsset {
        id = "powerbox_burger_spider_name"
      };
      burgerSpiderName.part_groups.Add("Burger,Spider");
      burgerSpiderName.part_groups.Add("-");
      burgerSpiderName.part_groups.Add("spider,burger");
      burgerSpiderName.addTemplate("part_group");
      return burgerSpiderName;
    }
  }
}
