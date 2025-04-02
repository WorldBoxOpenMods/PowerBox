using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class FishingBoatSpawnButton : ModGodPowerButtonFeature<FishingBoatSpawnPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(NonRandomFriendshipButton);
    public override string SpritePath => "actors/boats/boat_fishing";
  }
}
