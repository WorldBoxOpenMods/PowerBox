using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class LanguageDuplicationPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_duplicate_language",
        name = "powerbox_duplicate_language",
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = false,
        show_tool_sizes = false,
        unselect_when_window = true,
        click_special_action = LanguageDuplicationAction
      };
    }

    private static bool LanguageDuplicationAction(WorldTile pTile = null, string pPowerId = null) {
      City targetCity = pTile?.zone?.city;
      Language oldLanguage = targetCity?.getLanguage();
      if (oldLanguage == null) return false;
      Actor targetUnit = targetCity.hasLeader() ? targetCity.leader : targetCity.units.FirstOrDefault();
      if (targetUnit == null) return false;
      Language newLanguage = World.world.languages.newLanguage(targetUnit, false);
      foreach (LanguageTrait trait in oldLanguage._traits) newLanguage.addTrait(trait);
      foreach (Actor actor in targetCity.units) {
        actor.setLanguage(newLanguage);
      }
      return true;
    }
  }
}
