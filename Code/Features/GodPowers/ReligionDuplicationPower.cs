using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class ReligionDuplicationPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_duplicate_religion",
        name = "powerbox_duplicate_religion",
        force_map_mode = MetaType.Religion,
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = false,
        show_tool_sizes = false,
        unselect_when_window = true,
        click_special_action = ReligionDuplicationAction
      };
    }

    private static bool ReligionDuplicationAction(WorldTile pTile = null, string pPowerId = null) {
      City targetCity = pTile?.zone?.city;
      Religion oldReligion = targetCity?.getReligion();
      if (oldReligion == null) return false;
      Actor targetUnit = targetCity.hasLeader() ? targetCity.leader : targetCity.units.FirstOrDefault();
      if (targetUnit == null) return false;
      Religion newReligion = World.world.religions.newReligion(targetUnit, false);
      foreach (ReligionTrait trait in oldReligion._traits) newReligion.addTrait(trait);
      foreach (Actor actor in targetCity.units) {
        actor.setReligion(newReligion);
      }
      return true;
    }
  }
}
