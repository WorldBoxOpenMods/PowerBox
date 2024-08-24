using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class TradingBoatSpawnButton : GodPowerButtonFeature<TradingBoatSpawnPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(TransportBoatSpawnButton);
    public override string SpritePath => "actors/boats/boat_trading_dwarf";
  }
}
