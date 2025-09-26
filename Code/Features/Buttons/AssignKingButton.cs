using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class AssignKingButton : PowerboxGodPowerButtonFeature<AssignKingPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ColonyCreationButton);
    public override string SpritePath => "ui/icons/iconkings";

    public override TabSection Section => TabSection.Metas;
  }
}
