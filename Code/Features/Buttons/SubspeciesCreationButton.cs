using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class SubspeciesCreationButton : ModGodPowerButtonFeature<SubspeciesCreationPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ReligionAdditionButton);
    public override string SpritePath => "ui/icons/iconspecies";
  }
}
