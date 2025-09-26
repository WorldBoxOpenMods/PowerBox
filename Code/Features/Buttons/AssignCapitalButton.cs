using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class AssignCapitalButton : PowerboxGodPowerButtonFeature<AssignCapitalPower> {
    public override string SpritePath => "ui/icons/iconkingdom";
    public override ModFeatureRequirementList OptionalModFeatures => typeof(CityConversionButton);

    public override TabSection Section => TabSection.Metas;
  }
}
