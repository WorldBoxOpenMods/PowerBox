namespace PowerBox.Code.LoadingSystem {
  public abstract class ObjectFeature<TObject> : Feature {
    public TObject Object { get; private set; }
    internal override bool Init() {
      TObject obj = InitObject();
      if (obj == null) return false;
      Object = obj;
      return true;
    }
    protected abstract TObject InitObject();
    public static implicit operator TObject(ObjectFeature<TObject> feature) {
      return feature.Object;
    }
  }
}
