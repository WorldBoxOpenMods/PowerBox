using NeoModLoader.api.features;

namespace PowerBox.Code.Features.NameGenerators {
  public class Maxim : ModAssetFeature<NameGeneratorAsset> {
    protected override NameGeneratorAsset InitObject() {
      NameGeneratorAsset maximCreatureName = new NameGeneratorAsset {
        id = "powerbox_maxim_creature_name"
      };
      maximCreatureName.addPartGroup("Maxim,Max,Greg,dev");
      maximCreatureName.addPartGroup(" ");
      maximCreatureName.addPartGroup("Karpenko,dev,greg");
      maximCreatureName.addTemplate("part_group");
      return maximCreatureName;
    }
  }
}
