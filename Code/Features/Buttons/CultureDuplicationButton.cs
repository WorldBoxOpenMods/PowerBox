using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class CultureDuplicationButton : PowerboxGodPowerButtonFeature<CultureDuplicationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(CultureCreationButton);
    public override string SpritePath => "ui/icons/iconCloneCulture";

    protected override TabSection Section => TabSection.Metas;
  }
}
