using PowerBox.Code.Features.GodPowers;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Buttons {
  public class NonRandomFriendshipButton : ModGodPowerButtonFeature<NonRandomFriendshipPower, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(ClanAdditionButton);
    public override string SpritePath => "ui/icons/iconfriendship";
  }
}
