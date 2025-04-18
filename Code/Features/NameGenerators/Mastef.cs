using NeoModLoader.api.features;

namespace PowerBox.Code.Features.NameGenerators {
  public class Mastef : ModAssetFeature<NameGeneratorAsset> {
    protected override NameGeneratorAsset InitObject() {
      NameGeneratorAsset mastefCreatureName = new NameGeneratorAsset {
        id = "powerbox_mastef_creature_name"
      };
      mastefCreatureName.addPartGroup("Mastef,Markus,Big Lebovski,Greg,dev");
      mastefCreatureName.addPartGroup(" ");
      mastefCreatureName.addPartGroup("Stefanko,dev,greg");
      mastefCreatureName.addTemplate("part_group");
      return mastefCreatureName;
    }
  }
}
