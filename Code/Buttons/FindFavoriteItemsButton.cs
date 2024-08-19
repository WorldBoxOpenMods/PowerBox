using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Utils;

namespace PowerBox.Code.Buttons {
  public class FindFavoriteItemsButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(Windows.FindFavouriteItemsWindow) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(AllianceCreationButton) };
    internal override bool Init() {
      Tab.CreateClickButton(
        "find_favorite_items",
        AssetUtils.LoadEmbeddedSprite("powers/favourite_items_list"),
        Tab.PowerboxTabObject.transform,
        GetFeature<Windows.FindFavouriteItemsWindow>().FindFavoriteItemsButtonClick
      );
      return true;
    }
  }
}