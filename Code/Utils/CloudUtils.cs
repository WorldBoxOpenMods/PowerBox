namespace PowerBox.Code.Utils {
  public static class CloudUtils {
    public static void CloudSpawnAction(WorldTile pTile = null, string pDropID = null) {
      if (pDropID == null)
        return;

      WorldTile random = pDropID.EndsWith("D") ? pTile : MapBox.instance.tilesList.GetRandom();

      if (pDropID.EndsWith("D"))
        pDropID = pDropID.Remove(pDropID.Length - 1, 1);
      CloudAsset cloud;
      switch (pDropID) {
        case "cloudBurgerSpider":
          cloud = AssetManager.clouds.get("cloud_burger_spider");
          break;
        case "cloudBloodRain":
          cloud = AssetManager.clouds.get("cloud_blood_rain");
          break;
        default:
          return;
      }
      EffectsLibrary.spawn("fx_cloud", pTile: random, pParam1: cloud.id);
    }

  }
}