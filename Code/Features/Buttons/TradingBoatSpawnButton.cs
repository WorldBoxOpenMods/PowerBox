using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class TradingBoatSpawnButton : ModGodPowerButtonFeature<TradingBoatSpawnPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(TransportBoatSpawnButton);
    public override string SpritePath => "actors/boats/boat_trading_dwarf";
  }
}
