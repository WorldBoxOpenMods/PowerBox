using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class LanguageAdditionPower : ModAssetFeature<GodPower> {

    private static Language _targetLanguage;
    protected override GodPower InitObject() {
      DropAsset addToLanguageDrop = new DropAsset {
        id = "powerbox_add_unit_to_language",
        path_texture = "drops/drop_unity",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = AddUnitToLanguageAction
      };
      AssetManager.drops.add(addToLanguageDrop);

      GodPower addToLanguage = new GodPower {
        id = addToLanguageDrop.id,
        name = addToLanguageDrop.id,
        show_tool_sizes = true,
        falling_chance = 0.03f,
        hold_action = true,
        unselect_when_window = true,
        drop_id = addToLanguageDrop.id,
        cached_drop_asset = addToLanguageDrop,
        force_map_mode = MetaType.Language,
        click_power_action = (pTile, pPower) => _targetLanguage != null ? AssetManager.powers.spawnDrops(pTile, pPower) : TryGetLanguage(pTile, pPower),
        click_power_brush_action = AssetManager.powers.loopWithCurrentBrushPowerForDropsFull
      };

      return addToLanguage;
    }
    private static bool TryGetLanguage(WorldTile pTile = null, GodPower _ = null) {
      Language targetLanguage = Finder.getUnitsFromChunk(pTile, 1).Where(a => a.hasLanguage()).Select(a => a.language).FirstOrDefault();
      if (targetLanguage == null) return false;
      _targetLanguage = targetLanguage;
      return true;
    }
    private static void AddUnitToLanguageAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile == null) return;
      pTile.doUnits(a => AddUnitToLanguage(a));
      if (World.world.drop_manager._drops.Where(d => d._asset?.id == pDropID).Count(d => !d._landed) <= 1) {
        _targetLanguage = null;
      }
    }
    private static void AddUnitToLanguage(Actor actor, bool animate = true) {
      if (_targetLanguage == null) return;
      if (actor == null) return;
      actor.setLanguage(_targetLanguage);

      if (animate) {
        actor.startShake();
        actor.startColorEffect();
      }
    }
  }
}
