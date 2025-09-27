using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class CultureCreationButton : PowerboxGodPowerButtonFeature<CultureCreationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(CityBorderReductionButton);
    public override string SpritePath => "ui/icons/iconculture";

    protected override TabSection Section => TabSection.Metas;
  }
}
