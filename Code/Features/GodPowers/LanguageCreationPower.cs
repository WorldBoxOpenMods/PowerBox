using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class LanguageCreationPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_create_new_language",
        name = "powerbox_create_new_language",
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = false,
        show_tool_sizes = false,
        unselect_when_window = true,
        click_special_action = LanguageCreationAction
      };
    }

    private static bool LanguageCreationAction(WorldTile pTile = null, string pPowerId = null) {
      if (pTile?.zone?.city == null) return false;
      City targetCity = pTile.zone.city;
      Actor targetUnit = targetCity.hasLeader() ? targetCity.leader : targetCity.units.FirstOrDefault();
      if (targetUnit == null) return false;
      Language newLanguage = World.world.languages.newLanguage(targetUnit, true);
      foreach (Actor actor in targetCity.units) {
        actor.setLanguage(newLanguage);
      }
      return true;
    }
  }
}
