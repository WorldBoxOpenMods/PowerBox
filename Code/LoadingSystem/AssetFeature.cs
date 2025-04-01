using System.Linq;

namespace PowerBox.Code.LoadingSystem {
  public abstract class AssetFeature<TAsset> : ObjectFeature<TAsset> where TAsset : Asset {
    protected virtual bool AddToLibrary => true;
    internal override bool Init() {
      if (!base.Init()) return false;
      if (AddToLibrary) {
        AssetLibrary<TAsset> library = AssetManager._instance._list.OfType<AssetLibrary<TAsset>>().FirstOrDefault();
        if (library == null) throw new FeatureLoadException($"No library found for {typeof(TAsset).Name}");
        library.add(Object);
      }
      return true;
    }
  }
}
