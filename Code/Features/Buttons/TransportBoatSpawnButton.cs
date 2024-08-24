using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class TransportBoatSpawnButton : GodPowerButtonFeature<TransportBoatSpawnPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(FishingBoatSpawnButton);
    public override string SpritePath => "actors/boats/boat_transport_dwarf";
  }
}
