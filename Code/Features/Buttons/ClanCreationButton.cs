using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class ClanCreationButton : PowerboxGodPowerButtonFeature<ClanCreationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(AssignCapitalButton);
    public override string SpritePath => "ui/icons/iconclanlist";

    protected override TabSection Section => TabSection.Metas;
  }
}
