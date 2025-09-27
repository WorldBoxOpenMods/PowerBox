using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class TradingBoatSpawnButton : PowerboxGodPowerButtonFeature<TradingBoatSpawnPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(TransportBoatSpawnButton);
    public override string SpritePath => "actors/boats/boat_trading_dwarf";

    protected override TabSection Section => TabSection.Spawns;
  }
}
