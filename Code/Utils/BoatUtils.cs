namespace PowerBox.Code.Utils {
  public class BoatUtils {
    public static void BoatSpawnAction(WorldTile pTile, string boatType) {
      if (pTile.zone.city == null)
        return;

      if (!pTile.Type.liquid)
        return;

      Actor actor = MapBox.instance.units.spawnNewUnit(boatType, pTile);

      Kingdom kingdom = pTile.zone.city.kingdom;
      actor.setKingdom(kingdom);
      actor.setCity(pTile.zone.city);
    }
  }
}