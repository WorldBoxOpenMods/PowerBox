using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class ReligionAdditionPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset addToReligionDrop = new DropAsset {
        id = "powerbox_add_unit_to_religion",
        path_texture = "drops/drop_unity",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = AddUnitToReligionAction
      };
      AssetManager.drops.add(addToReligionDrop);

      GodPower addToReligion = new GodPower {
        id = addToReligionDrop.id,
        name = addToReligionDrop.id,
        show_tool_sizes = true,
        falling_chance = 0.03f,
        hold_action = true,
        unselect_when_window = true,
        drop_id = addToReligionDrop.id,
        cached_drop_asset = addToReligionDrop,
        force_map_mode = MetaType.Religion,
        click_power_action = (pTile, pPower) => _targetReligion != null ? AssetManager.powers.spawnDrops(pTile, pPower) : TryGetReligion(pTile, pPower),
        click_power_brush_action = AssetManager.powers.loopWithCurrentBrushPowerForDropsFull
      };

      return addToReligion;
    }

    private static Religion _targetReligion;
    private static bool TryGetReligion(WorldTile pTile = null, GodPower _ = null) {
      Religion targetReligion = Finder.getUnitsFromChunk(pTile, 1).Where(a => a.hasReligion()).Select(a => a.religion).FirstOrDefault();
      if (targetReligion == null) return false;
      _targetReligion = targetReligion;
      return true;
    }
    private static void AddUnitToReligionAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile == null) return;
      pTile.doUnits((a) => AddUnitToReligion(a));
      if (World.world.drop_manager._drops.Where(d => d._asset?.id == pDropID).Count(d => !d._landed) <= 1) {
        _targetReligion = null;
      }
    }
    private static void AddUnitToReligion(Actor actor, bool animate = true) {
      if (_targetReligion == null) return;
      if (actor == null) return;
      actor.setReligion(_targetReligion);

      if (animate) {
        actor.startShake();
        actor.startColorEffect();
      }
    }
  }
}
