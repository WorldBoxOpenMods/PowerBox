using PowerBox.Code.Features.Windows;
using PowerBox.Code.LoadingSystem;
using UnityEngine.Events;

namespace PowerBox.Code.Features.Buttons {
  public class AboutModButton : WindowButtonFeature<AboutPowerboxWindow, Tab> {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures + typeof(AboutPowerboxWindow);
    public override UnityAction WindowOpenAction => () => GetFeature<AboutPowerboxWindow>().Object.clickShow();
    public override string SpritePath => "ui/icons/iconabout";
  }
}
