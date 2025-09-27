using NeoModLoader.api;
using PowerBox.Code.Features.Windows;
using UnityEngine.Events;

namespace PowerBox.Code.Features.Buttons {
  public class AboutModButton : PowerboxWindowButtonFeature<AboutPowerboxWindow> {
    public override ModFeatureRequirementList RequiredModFeatures => base.RequiredModFeatures + typeof(AboutPowerboxWindow);
    public override UnityAction WindowOpenAction => () => GetFeature<AboutPowerboxWindow>().Object.clickShow();
    public override string SpritePath => "ui/icons/iconabout";

    protected override TabSection Section => TabSection.All;
  }
}
