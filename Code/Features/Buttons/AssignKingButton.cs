using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class AssignKingButton : PowerboxGodPowerButtonFeature<AssignKingPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ColonyCreationButton);
    public override string SpritePath => "ui/icons/iconkings";

    protected override TabSection Section => TabSection.Metas;
  }
}
