using PowerBox.Code.Features.Windows;
using PowerBox.Code.LoadingSystem;
using UnityEngine.Events;

namespace PowerBox.Code.Features.Buttons {
  public class FindAllCreaturesButton : WindowButtonFeature<FindAllCreaturesWindow, Tab> {
    internal override FeatureRequirementList OptionalFeatures => typeof(AllianceCreationButton);
    public override UnityAction WindowOpenAction => GetFeature<FindAllCreaturesWindow>().FindAllCreaturesButtonClick;
    public override string SpritePath => "ui/icons/iconbrowse2";
  }
}
