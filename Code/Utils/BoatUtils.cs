namespace PowerBox.Code.Utils {
  public class BoatUtils {
    public static void BoatSpawnAction(WorldTile pTile, string boatType) {
      if (pTile.zone.city == null) return;
      if (!pTile.Type.liquid) return;

      if (boatType != "boat_fishing") {
        Subspecies subspecies = pTile.zone.city.getMainSubspecies();
        if (subspecies == null) return;
        boatType += $"_{subspecies.species_id}";
      }

      Actor actor = MapBox.instance.units.spawnNewUnit(boatType, pTile);

      Kingdom kingdom = pTile.zone.city.kingdom;
      actor.setKingdom(kingdom);
      actor.setCity(pTile.zone.city);
    }
  }
}
