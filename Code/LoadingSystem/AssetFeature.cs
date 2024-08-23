using System.Linq;

namespace PowerBox.Code.LoadingSystem {
  public abstract class AssetFeature<TAsset> : ObjectFeature<TAsset> where TAsset : Asset {
    internal override bool Init() {
      if (!base.Init()) return false;
      AssetLibrary<TAsset> library = AssetManager.instance.list.OfType<AssetLibrary<TAsset>>().FirstOrDefault();
      if (library == null) throw new FeatureLoadException($"No library found for {typeof(TAsset).Name}");
      library.add(Object);
      return true;
    }
  }
}