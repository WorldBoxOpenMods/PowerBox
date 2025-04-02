using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ClanAdditionButton : ModGodPowerButtonFeature<ClanAdditionPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ClanCreationButton);
    public override string SpritePath => "ui/icons/iconclanzones";
  }
}
