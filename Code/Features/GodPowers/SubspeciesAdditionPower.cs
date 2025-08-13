using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class SubspeciesAdditionPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset addToSubspeciesDrop = new DropAsset {
        id = "powerbox_add_unit_to_subspecies",
        path_texture = "drops/drop_unity",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = AddUnitToSubspeciesAction
      };
      AssetManager.drops.add(addToSubspeciesDrop);

      GodPower addToSubspecies = new GodPower {
        id = addToSubspeciesDrop.id,
        name = addToSubspeciesDrop.id,
        show_tool_sizes = true,
        falling_chance = 0.03f,
        hold_action = true,
        unselect_when_window = true,
        drop_id = addToSubspeciesDrop.id,
        cached_drop_asset = addToSubspeciesDrop,
        force_map_mode = MetaType.Subspecies,
        click_power_action = (pTile, pPower) => _targetSubspecies != null ? AssetManager.powers.spawnDrops(pTile, pPower) : TryGetSubspecies(pTile, pPower),
        click_power_brush_action = AssetManager.powers.loopWithCurrentBrushPowerForDropsFull
      };

      return addToSubspecies;
    }

    private static Subspecies _targetSubspecies;
    private static bool TryGetSubspecies(WorldTile pTile = null, GodPower _ = null) {
      Subspecies targetSubspecies = Finder.getUnitsFromChunk(pTile, 1).Where(a => a.hasSubspecies()).Select(a => a.subspecies).FirstOrDefault();
      if (targetSubspecies == null) return false;
      _targetSubspecies = targetSubspecies;
      return true;
    }
    private static void AddUnitToSubspeciesAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile == null) return;
      pTile.doUnits((a) => AddUnitToSubspecies(a));
      if (World.world.drop_manager._drops.Where(d => d._asset?.id == pDropID).Count(d => !d._landed) <= 1) {
        _targetSubspecies = null;
      }
    }
    private static void AddUnitToSubspecies(Actor actor, bool animate = true) {
      if (_targetSubspecies == null) return;
      if (actor == null) return;
      actor.setSubspecies(_targetSubspecies);

      if (animate) {
        actor.startShake();
        actor.startColorEffect();
      }
    }
  }
}
