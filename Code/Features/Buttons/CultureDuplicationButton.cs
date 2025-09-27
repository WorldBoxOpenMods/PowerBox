using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class CultureDuplicationButton : PowerboxGodPowerButtonFeature<CultureDuplicationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(CultureCreationButton);
    public override string SpritePath => "ui/icons/clone_culture";

    protected override TabSection Section => TabSection.Metas;
  }
}
