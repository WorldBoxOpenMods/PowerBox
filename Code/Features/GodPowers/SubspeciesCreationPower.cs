using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class SubspeciesCreationPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_create_new_subspecies",
        name = "powerbox_create_new_subspecies",
        force_map_mode = MetaType.Subspecies,
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = false,
        show_tool_sizes = false,
        unselect_when_window = true,
        click_special_action = SubspeciesCreationAction
      };
    }

    private static bool SubspeciesCreationAction(WorldTile pTile = null, string pPowerId = null) {
      Actor targetUnit = Finder.getUnitsFromChunk(pTile, 1, 2).FirstOrDefault(actor => actor.isAlive());
      if (targetUnit == null) return false;
      targetUnit.subspecies.units.Remove(targetUnit);
      Subspecies newSpecies = World.world.subspecies.newSpecies(targetUnit.asset, targetUnit.current_tile);
      targetUnit.setSubspecies(newSpecies);
      return true;
    }
  }
}
