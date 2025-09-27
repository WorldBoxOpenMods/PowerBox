using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class CityBorderExpansionButton : PowerboxGodPowerButtonFeature<CityBorderExpansionPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(BuildingDowngradeButton);
    public override string SpritePath => "powers/expand_city_borders";

    protected override TabSection Section => TabSection.Metas;
  }
}
