using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.NameGenerators {
  public class Maxim : AssetFeature<NameGeneratorAsset> {
    protected override NameGeneratorAsset InitObject() {
      NameGeneratorAsset maximCreatureName = new NameGeneratorAsset {
        id = "powerbox_maxim_creature_name"
      };
      maximCreatureName.part_groups.Add("Maxim,Max,Greg,dev");
      maximCreatureName.part_groups.Add(" ");
      maximCreatureName.part_groups.Add("Karpenko,dev,greg");
      maximCreatureName.templates.Add("part_group");
      return maximCreatureName;
    }
  }
}
