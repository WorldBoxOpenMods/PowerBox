using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class CityConversionButton : PowerboxGodPowerButtonFeature<CityConversionPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(AssignLeaderButton);
    public override string SpritePath => "ui/icons/iconcityselect";

    protected override TabSection Section => TabSection.Metas;
  }
}
