using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class TransportBoatSpawnButton : ModGodPowerButtonFeature<TransportBoatSpawnPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(FishingBoatSpawnButton);
    public override string SpritePath => "actors/boats/boat_transport_dwarf";
  }
}
