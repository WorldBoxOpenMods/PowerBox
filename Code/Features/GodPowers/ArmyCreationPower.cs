using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class ArmyCreationPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_create_new_army",
        name = "powerbox_create_new_army",
        force_map_mode = MetaType.Army,
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = false,
        show_tool_sizes = false,
        unselect_when_window = true,
        click_special_action = ArmyCreationAction
      };
    }

    private static bool ArmyCreationAction(WorldTile pTile = null, string pPowerId = null) {
      Actor targetUnit = Finder.getUnitsFromChunk(pTile, 1, 2).FirstOrDefault(actor => actor.isAlive());
      if (targetUnit == null) return false;
      City targetCity = targetUnit.city;
      if (targetUnit.hasArmy()) targetUnit.army.units.Remove(targetUnit);
      Army newArmy = World.world.armies.newArmy(targetUnit, targetCity);
      targetUnit.setArmy(newArmy);
      targetUnit.army.setCaptain(targetUnit);
      return true;
    }
  }
}
