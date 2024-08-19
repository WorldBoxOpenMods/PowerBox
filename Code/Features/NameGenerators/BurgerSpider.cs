using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.NameGenerators {
  public class BurgerSpider : Feature {
    internal override bool Init() {
      NameGeneratorAsset burgerSpiderName = new NameGeneratorAsset {
        id = "burger_spider_name"
      };
      burgerSpiderName.part_groups.Add("Burger,Spider");
      burgerSpiderName.part_groups.Add("-");
      burgerSpiderName.part_groups.Add("spider,burger");
      burgerSpiderName.templates.Add("part_group");
      AssetManager.nameGenerator.add(burgerSpiderName);
      return true;
    }
  }
}