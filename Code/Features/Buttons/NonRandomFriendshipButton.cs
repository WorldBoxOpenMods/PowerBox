using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class NonRandomFriendshipButton : PowerboxGodPowerButtonFeature<NonRandomFriendshipPower> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ClanAdditionButton);
    public override string SpritePath => "ui/icons/iconfriendship";

    protected override TabSection Section => TabSection.Metas;
  }
}
