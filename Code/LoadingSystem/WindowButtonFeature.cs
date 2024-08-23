using NeoModLoader.General;
using UnityEngine;
using UnityEngine.Events;

namespace PowerBox.Code.LoadingSystem {
  public abstract class WindowButtonFeature<TWindowFeature, TPowersTabFeature> : ButtonFeature<TPowersTabFeature> where TWindowFeature : ObjectFeature<ScrollWindow> where TPowersTabFeature : PowerTabFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures + typeof(TWindowFeature);
    protected ScrollWindow Window => GetFeature<TWindowFeature>();
    public abstract UnityAction WindowOpenAction { get; }
    public abstract string SpritePath { get; }
    protected override PowerButton InitObject() {
      return PowerButtonCreator.CreateSimpleButton(
        Window.name,
        WindowOpenAction,
        Resources.Load<Sprite>(SpritePath),
        Tab.transform
      );
    }
  }
}
