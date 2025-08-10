using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class ReligionCreationPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_create_new_religion",
        name = "powerbox_create_new_religion",
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = false,
        show_tool_sizes = false,
        unselect_when_window = true,
        click_special_action = ReligionCreationAction
      };
    }

    private static bool ReligionCreationAction(WorldTile pTile = null, string pPowerId = null) {
      if (pTile?.zone?.city == null) return false;
      City targetCity = pTile.zone.city;
      Actor targetUnit = targetCity.hasLeader() ? targetCity.leader : targetCity.units.FirstOrDefault();
      if (targetUnit == null) return false;
      Culture newCulture = null;
      Language newLanguage = null;
      Religion newReligion = World.world.religions.newReligion(targetUnit, true);
      foreach (Actor actor in targetCity.units) {
        if (!actor.hasCulture()) {
          if (newCulture == null) {
            newCulture = World.world.cultures.newCulture(targetUnit, true);
          }
          actor.setCulture(newCulture);
        }
        if (!actor.hasLanguage()) {
          if (newLanguage == null) {
            newLanguage = World.world.languages.newLanguage(targetUnit, true);
          }
          actor.setLanguage(newLanguage);
        }
        actor.setReligion(newReligion);
      }
      return true;
    }
  }
}
