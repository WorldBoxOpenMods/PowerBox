using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.Windows;
using PowerBox.Code.Utils;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public class FindAllCreaturesButton : ButtonFeature {
    internal override List<Type> RequiredFeatures => base.RequiredFeatures.Concat(new []{ typeof(FindAllCreaturesWindow) }).ToList();
    internal override List<Type> OptionalFeatures => new List<Type>{ typeof(FindFavoriteItemsButton) };
    internal override bool Init() {
      Tab.CreateClickButton(
        "find_all_creatures",
        Resources.Load<Sprite>("ui/icons/iconbrowse2"),
        Tab.PowerboxTabObject.transform,
        GetFeature<FindAllCreaturesWindow>().FindAllCreaturesButtonClick
      );
      return true;
    }
  }
}
