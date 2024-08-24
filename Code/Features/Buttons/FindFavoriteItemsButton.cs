using PowerBox.Code.Features.Windows;
using PowerBox.Code.LoadingSystem;
using UnityEngine.Events;

namespace PowerBox.Code.Features.Buttons {
  public class FindFavoriteItemsButton : WindowButtonFeature<FindFavouriteItemsWindow, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(AllianceCreationButton);
    public override UnityAction WindowOpenAction => GetFeature<FindFavouriteItemsWindow>().FindFavoriteItemsButtonClick;
    public override string SpritePath => "powers/favourite_items_list";
  }
}
