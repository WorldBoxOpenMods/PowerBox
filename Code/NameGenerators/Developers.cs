using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.NameGenerators {
  public class Developers : Feature {
    internal override bool Init() {
      
      NameGeneratorAsset maximCreatureName = new NameGeneratorAsset {
        id = "maxim_creature_name"
      };
      maximCreatureName.part_groups.Add("Maxim,Max,Greg,dev");
      maximCreatureName.part_groups.Add(" ");
      maximCreatureName.part_groups.Add("Karpenko,dev,greg");
      maximCreatureName.templates.Add("part_group");
      AssetManager.nameGenerator.add(maximCreatureName);

      NameGeneratorAsset mastefCreatureName = new NameGeneratorAsset {
        id = "mastef_creature_name"
      };
      mastefCreatureName.part_groups.Add("Mastef,Markus,Big Lebovski,Greg,dev");
      mastefCreatureName.part_groups.Add(" ");
      mastefCreatureName.part_groups.Add("Stefanko,dev,greg");
      mastefCreatureName.templates.Add("part_group");
      AssetManager.nameGenerator.add(mastefCreatureName);
      return true;
    }
  }
}