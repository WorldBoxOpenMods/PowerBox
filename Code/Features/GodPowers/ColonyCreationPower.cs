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
      foreach (Actor actor in from Actor a in Finder.getUnitsFromChunk(pTile, 1, 2) where a.isAlive() && !a.asset.is_boat && a.subspecies.isSapient() select a) {
        actor.startShake();
        actor.startColorEffect();

        if (actor.current_tile.zone.city == null) {
          if (actor.kingdom == null) {
            World.world.kingdoms.makeNewCivKingdom(actor);
            if (actor.kingdom == null)
              continue;
          } else if (actor.kingdom.isNomads()) {
            World.world.kingdoms.makeNewCivKingdom(actor);
          }
          if (actor.kingdom.isCiv()) {
            actor.city?.eventUnitRemoved(actor);
            World.world.cities.buildNewCity(actor, actor.current_tile.zone);
          }
        } else {
          if (pTile != null && actor.city != actor.current_tile.zone.city) {
            actor.city?.eventUnitRemoved(actor);
            actor.city = actor.current_tile.zone.city;
            actor.city.eventUnitAdded(actor);
            actor.kingdom = actor.city.kingdom;
          }
        }
      }
    }

  }
}
