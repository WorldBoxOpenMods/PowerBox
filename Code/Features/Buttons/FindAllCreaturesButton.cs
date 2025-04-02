using PowerBox.Code.Features.Windows;
using NeoModLoader.api;
using NeoModLoader.api.features;
using UnityEngine.Events;

namespace PowerBox.Code.Features.Buttons {
  public class FindAllCreaturesButton : ModWindowButtonFeature<FindAllCreaturesWindow, Tab> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(AllianceCreationButton);
    public override UnityAction WindowOpenAction => GetFeature<FindAllCreaturesWindow>().FindAllCreaturesButtonClick;
    public override string SpritePath => "ui/icons/iconbrowse2";
  }
}
