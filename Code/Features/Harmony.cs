using NeoModLoader.api.features;

namespace PowerBox.Code.Features {
  public class Harmony : ModObjectFeature<HarmonyLib.Harmony> {
    public HarmonyLib.Harmony Instance => Object;
    protected override HarmonyLib.Harmony InitObject() {
      return new HarmonyLib.Harmony("key.worldbox.powerbox");
    }
  }
}
