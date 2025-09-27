using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class ColonyCreationButton : PowerboxGodPowerButtonFeature<ColonyCreationPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ArmyRemovalButton);
    public override string SpritePath => "powers/colonies";

    protected override TabSection Section => TabSection.Metas;
  }
}
