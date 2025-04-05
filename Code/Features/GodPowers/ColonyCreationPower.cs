using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class ColonyCreationPower : ModAssetFeature<GodPower> {
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
        show_tool_sizes = false,
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = true,
        unselect_when_window = true,
        drop_id = makeColonyDrop.id,
        cached_drop_asset = makeColonyDrop,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      return makeColony;
    }
    private static void ColonyCreationAction(WorldTile pTile = null, string pDropID = null) {
      foreach (Actor actor in from Actor a in Finder.getUnitsFromChunk(pTile, 4) where a.isAlive() && !a.asset.is_boat select a) {
        actor.startShake();
        actor.startColorEffect();

        if (actor.current_tile.zone.city == null) {
          if (actor.kingdom.isCiv() || actor.kingdom.isNomads()) {
            
            Kingdom kingdom = actor.kingdom;
            MapBox world = MapBox.instance;

            TileZone zone = actor.current_tile.zone;

            if (kingdom != null && kingdom.isNomads())
              kingdom = null;
            
            City city1 = world.cities.buildNewCity(actor, zone);

            if (city1 == null)
              return;

            city1.newCityEvent(actor);

            City city2 = actor.city;
            city2?.eventUnitRemoved(actor);
            actor.city = city1;
            city1.eventUnitAdded(actor);
            WorldLog.logNewCity(city1);
          }
        } else {
          if (pTile != null && actor.city != pTile.zone.city) {
            actor.city?.eventUnitRemoved(actor);
            actor.city = pTile.zone.city;
            pTile.zone.city.eventUnitAdded(actor);
            Kingdom kingdomN = pTile.zone.city.kingdom;
            actor.kingdom = kingdomN;
          }
        }
      }
    }

  }
}
