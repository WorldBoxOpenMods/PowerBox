using PowerBox.Code.Features.GodPowers;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Buttons {
  public class NonRandomFriendshipButton : GodPowerButtonFeature<NonRandomFriendshipPower, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(ClanAdditionButton);
    public override string SpritePath => "ui/icons/iconfriendship";
  }
}
