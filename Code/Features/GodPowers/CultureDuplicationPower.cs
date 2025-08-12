using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class CultureDuplicationPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_duplicate_culture",
        name = "powerbox_duplicate_culture",
        force_map_mode = MetaType.Culture,
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = false,
        show_tool_sizes = false,
        unselect_when_window = true,
        click_special_action = CultureDuplicationAction
      };
    }

    private static bool CultureDuplicationAction(WorldTile pTile = null, string pPowerId = null) {
      City targetCity = pTile?.zone?.city;
      Culture oldCulture = targetCity?.getCulture();
      if (oldCulture == null) return false;
      Actor targetUnit = targetCity.hasLeader() ? targetCity.leader : targetCity.units.FirstOrDefault();
      if (targetUnit == null) return false;
      Culture newCulture = World.world.cultures.newCulture(targetUnit, false);
      foreach (CultureTrait trait in oldCulture._traits) newCulture.addTrait(trait);
      foreach (Actor actor in targetCity.units) {
        actor.setCulture(newCulture);
      }
      return true;
    }
  }
}
