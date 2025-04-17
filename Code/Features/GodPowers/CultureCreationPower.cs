using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class CultureCreationPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_create_new_culture",
        name = "powerbox_create_new_culture",
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = false,
        show_tool_sizes = false,
        unselect_when_window = true,
        click_special_action = CultureCreationAction
      };
    }

    private static bool CultureCreationAction(WorldTile pTile = null, string pPowerId = null) {
      if (pTile?.zone?.city == null) return false;
      City targetCity = pTile.zone.city;
      Actor targetUnit = targetCity.hasLeader() ? targetCity.leader : targetCity.units.FirstOrDefault();
      if (targetUnit == null) return false;
      Culture newCulture = World.world.cultures.newCulture(targetUnit, true);
      foreach (Actor actor in targetCity.units) {
        actor.setCulture(newCulture);
      }
      return true;
    }
  }
}
