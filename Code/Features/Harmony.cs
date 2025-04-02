using PowerBox.Code.LoadingSystem;
namespace PowerBox.Code.Features {
  public class Harmony : ObjectFeature<HarmonyLib.Harmony> {
    public HarmonyLib.Harmony Instance => Object;
    protected override HarmonyLib.Harmony InitObject() {
      return new HarmonyLib.Harmony("key.worldbox.powerbox");
    }
  }
}
