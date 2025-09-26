using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ClanCreationButton : PowerboxGodPowerButtonFeature<ClanCreationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(AssignCapitalButton);
    public override string SpritePath => "ui/icons/iconclanlist";

    public override TabSection Section => TabSection.Metas;
  }
}
