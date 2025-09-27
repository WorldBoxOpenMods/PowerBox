using NeoModLoader.api;
using PowerBox.Code.Features.Windows;
using UnityEngine.Events;

namespace PowerBox.Code.Features.Buttons {
  public class FindAllCreaturesButton : PowerboxWindowButtonFeature<FindAllCreaturesWindow> {
    public override ModFeatureRequirementList OptionalModFeatures => typeof(AllianceCreationButton);
    public override UnityAction WindowOpenAction => GetFeature<FindAllCreaturesWindow>().FindAllCreaturesButtonClick;
    public override string SpritePath => "ui/icons/iconbrowse2";

    protected override TabSection Section => TabSection.Info;
  }
}
