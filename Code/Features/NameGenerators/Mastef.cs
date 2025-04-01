using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.NameGenerators {
  public class Mastef : AssetFeature<NameGeneratorAsset> {
    protected override NameGeneratorAsset InitObject() {
      NameGeneratorAsset mastefCreatureName = new NameGeneratorAsset {
        id = "powerbox_mastef_creature_name"
      };
      mastefCreatureName.part_groups.Add("Mastef,Markus,Big Lebovski,Greg,dev");
      mastefCreatureName.part_groups.Add(" ");
      mastefCreatureName.part_groups.Add("Stefanko,dev,greg");
      mastefCreatureName.addTemplate("part_group");
      return mastefCreatureName;
    }
  }
}
