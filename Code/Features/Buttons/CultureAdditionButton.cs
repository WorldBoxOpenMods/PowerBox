using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class CultureAdditionButton : PowerboxGodPowerButtonFeature<CultureAdditionPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(CultureDuplicationButton);
    public override string SpritePath => "ui/icons/iconculturezones";

    protected override TabSection Section => TabSection.Metas;
  }
}
