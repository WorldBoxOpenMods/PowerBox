using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class CultureAdditionButton : ModGodPowerButtonFeature<CultureAdditionPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(CultureDuplicationButton);
    public override string SpritePath => "ui/icons/iconculturezones";
  }
}
