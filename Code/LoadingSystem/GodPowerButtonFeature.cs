using NeoModLoader.General;
using UnityEngine;

namespace PowerBox.Code.LoadingSystem {
  public abstract class GodPowerButtonFeature<TGodPowerFeature, TPowersTabFeature> : ButtonFeature<TPowersTabFeature> where TGodPowerFeature : AssetFeature<GodPower> where TPowersTabFeature : PowerTabFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures + typeof(TGodPowerFeature);
    public abstract string SpritePath { get; }
    protected override PowerButton InitObject() {
      return PowerButtonCreator.CreateGodPowerButton(
        GetFeature<TGodPowerFeature>().Object.id,
        Resources.Load<Sprite>(SpritePath),
        Tab.transform
      );
    }
  }
}
