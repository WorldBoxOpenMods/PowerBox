using NeoModLoader.api;
using PowerBox.Code.Features.GodPowers;

namespace PowerBox.Code.Features.Buttons {
  public class AllianceCreationButton : PowerboxGodPowerButtonFeature<AllianceCreationPower> {
    public override string SpritePath => "ui/icons/iconalliance";
    public override ModFeatureRequirementList OptionalModFeatures => typeof(BurgerSpiderCloudSpawnButton);

    protected override TabSection Section => TabSection.Metas;
  }
}
