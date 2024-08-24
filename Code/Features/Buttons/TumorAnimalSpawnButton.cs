using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class TumorAnimalSpawnButton : GodPowerButtonFeature<TumorAnimalSpawnPower, Tab> {
    public override string SpritePath => "powers/tumor_animal_icon";
    internal override FeatureRequirementList OptionalFeatures => typeof(TumorCreatureSpawnButton);
  }
}
