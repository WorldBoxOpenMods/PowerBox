using PowerBox.Code.Features.Windows;
using NeoModLoader.api;
using NeoModLoader.api.features;
using UnityEngine.Events;

namespace PowerBox.Code.Features.Buttons {
  public class AboutModButton : ModWindowButtonFeature<AboutPowerboxWindow, Tab> {
    public override ModFeatureRequirementList RequiredModFeatures => base.RequiredModFeatures + typeof(AboutPowerboxWindow);
    public override UnityAction WindowOpenAction => () => GetFeature<AboutPowerboxWindow>().Object.clickShow();
    public override string SpritePath => "ui/icons/iconabout";
  }
}
