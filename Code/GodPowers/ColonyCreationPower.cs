using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.GodPowers {
  public class ColonyCreationPower : Feature {
    internal override bool Init() {
      GodPower makeColony = new GodPower {
        id = "makeColony",
        name = "makeColony",
        showToolSizes = false,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        dropID = "makeColony",
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      AssetManager.powers.add(makeColony);


      DropAsset makeColonyDrop = new DropAsset {
        id = "makeColony",
        path_texture = "drops/drop_gold",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = ColonyCreationAction
      };
      AssetManager.drops.add(makeColonyDrop);

      return true;
    }
    private static void ColonyCreationAction(WorldTile pTile = null, string pDropID = null) {
      MapBox.instance.getObjectsInChunks(pTile, 4, MapObjectType.Actor);
      List<BaseSimObject> tempMapObjects = MapBox.instance.temp_map_objects;

      foreach (Actor tempMapObject in from Actor tempMapObject in tempMapObjects where tempMapObject.base_data.alive && tempMapObject.kingdom.isCiv() let ai = tempMapObject.ai select tempMapObject) {
        tempMapObject.startShake();
        tempMapObject.startColorEffect();

        if (tempMapObject.currentTile.zone.city == null) {
          Kingdom kingdom = tempMapObject.kingdom;
          MapBox world = MapBox.instance;

          TileZone zone = tempMapObject.currentTile.zone;

          if (kingdom != null && kingdom.isNomads())
            kingdom = null;

          Race race = tempMapObject.race;

          City city1 = world.cities.buildNewCity(zone, race, kingdom);

          if (city1 == null)
            return;

          city1.newCityEvent();

          city1.race = race;


          City city2 = tempMapObject.city;
          if (city2 != null) {

            tempMapObject.kingdom.newCityBuiltEvent(city1);
            city2.removeCitizen(tempMapObject);
            tempMapObject.removeFromCity();
          }
          tempMapObject.becomeCitizen(city1);
          WorldLog.logNewCity(city1);
        } else {
          if (pTile != null && tempMapObject.city != pTile.zone.city) {
            tempMapObject.city.removeCitizen(tempMapObject);
            tempMapObject.removeFromCity();
            tempMapObject.becomeCitizen(pTile.zone.city);
            Kingdom kingdomN = pTile.zone.city.kingdom;
            tempMapObject.kingdom = kingdomN;
          }
        }
      }
    }

  }
}