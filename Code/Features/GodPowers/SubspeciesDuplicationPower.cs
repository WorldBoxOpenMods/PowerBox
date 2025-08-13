using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class SubspeciesDuplicationPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_duplicate_subspecies",
        name = "powerbox_duplicate_subspecies",
        force_map_mode = MetaType.Subspecies,
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = false,
        show_tool_sizes = false,
        unselect_when_window = true,
        click_special_action = SubspeciesDuplicationAction
      };
    }

    private static bool SubspeciesDuplicationAction(WorldTile pTile = null, string pPowerId = null) {
      Actor targetUnit = Finder.getUnitsFromChunk(pTile, 1, 2).FirstOrDefault(actor => actor.isAlive());
      if (targetUnit == null) return false;
      Subspecies oldSpecies = World.world.subspecies.getNearbySpecies(targetUnit.asset, targetUnit.current_tile, out targetUnit, true);
      Subspecies newSpecies = World.world.subspecies.newSpecies(targetUnit.asset, targetUnit.current_tile);
      foreach (SubspeciesTrait trait in oldSpecies._traits) newSpecies.addTrait(trait);
      // TODO: make it also copy over genomes and birth traits
      targetUnit.setSubspecies(newSpecies);
      return true;
    }
  }
}
