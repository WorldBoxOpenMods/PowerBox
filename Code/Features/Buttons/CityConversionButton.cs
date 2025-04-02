using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class CityConversionButton : ModGodPowerButtonFeature<CityConversionPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(AssignLeaderButton);
    public override string SpritePath => "ui/icons/iconcityselect";
  }
}
