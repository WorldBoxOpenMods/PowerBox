using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class FishingBoatSpawnButton : GodPowerButtonFeature<FishingBoatSpawnPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(NonRandomFriendshipButton);
    public override string SpritePath => "actors/boats/boat_fishing";
  }
}
