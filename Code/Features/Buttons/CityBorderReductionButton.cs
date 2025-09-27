using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class CityBorderReductionButton : PowerboxGodPowerButtonFeature<CityBorderReductionPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(CityBorderExpansionButton);
    public override string SpritePath => "powers/reduce_city_borders";

    protected override TabSection Section => TabSection.Metas;
  }
}
