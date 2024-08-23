namespace PowerBox.Code.LoadingSystem {
  public abstract class ButtonFeature<TPowersTabFeature> : ObjectFeature<PowerButton> where TPowersTabFeature : PowerTabFeature {
    internal override FeatureRequirementList RequiredFeatures => base.RequiredFeatures + typeof(TPowersTabFeature);
    protected PowersTab Tab => GetFeature<TPowersTabFeature>();
    internal override bool Init() {
      return base.Init() && GetFeature<TPowersTabFeature>().PositionButton(Object);
    }
  }
}
