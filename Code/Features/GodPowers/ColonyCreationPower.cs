using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class ColonyCreationPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset makeColonyDrop = new DropAsset {
        id = "powerbox_create_colony",
        path_texture = "drops/drop_gold",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = ColonyCreationAction
      };
      AssetManager.drops.add(makeColonyDrop);
      
      GodPower makeColony = new GodPower {
        id = makeColonyDrop.id,
        name = makeColonyDrop.id,
        showToolSizes = false,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        dropID = makeColonyDrop.id,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      return makeColony;
    }
    private static void ColonyCreationAction(WorldTile pTile = null, string pDropID = null) {
      MapBox.instance.getObjectsInChunks(pTile, 4, MapObjectType.Actor);
      List<BaseSimObject> tempMapObjects = MapBox.instance.temp_map_objects;

      foreach (Actor tempMapObject in from Actor tempMapObject in tempMapObjects where tempMapObject.base_data.alive && !tempMapObject.asset.isBoat select tempMapObject) {
        tempMapObject.startShake();
        tempMapObject.startColorEffect();

        if (tempMapObject.currentTile.zone.city == null) {
          if (tempMapObject.kingdom.isCiv() || tempMapObject.kingdom.isNomads()) {
            
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
          }
        } else {
          if (pTile != null && tempMapObject.city != pTile.zone.city) {
            if (tempMapObject.city != null) {
              tempMapObject.city.removeCitizen(tempMapObject);
              tempMapObject.removeFromCity();
            }
            tempMapObject.becomeCitizen(pTile.zone.city);
            Kingdom kingdomN = pTile.zone.city.kingdom;
            tempMapObject.kingdom = kingdomN;
          }
        }
      }
    }

  }
}
