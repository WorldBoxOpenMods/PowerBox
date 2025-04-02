using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class CityBorderReductionButton : ModGodPowerButtonFeature<CityBorderReductionPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(CityBorderExpansionButton);
    public override string SpritePath => "powers/borders2";
  }
}
