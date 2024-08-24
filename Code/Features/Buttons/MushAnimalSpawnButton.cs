using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class MushAnimalSpawnButton : GodPowerButtonFeature<MushAnimalSpawnPower, Tab> {
    public override string SpritePath => "powers/mush_animal_icon";
    internal override FeatureRequirementList OptionalFeatures => typeof(MushCreatureSpawnButton);
  }
}
