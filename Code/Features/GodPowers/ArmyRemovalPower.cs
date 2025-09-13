using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class ArmyRemovalPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset removeFromArmyDrop = new DropAsset {
        id = "powerbox_remove_unit_from_army",
        path_texture = "drops/drop_unity",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = RemoveUnitFromArmyAction
      };
      AssetManager.drops.add(removeFromArmyDrop);

      GodPower removeFromArmy = new GodPower {
        id = removeFromArmyDrop.id,
        name = removeFromArmyDrop.id,
        show_tool_sizes = true,
        falling_chance = 0.03f,
        hold_action = true,
        unselect_when_window = true,
        drop_id = removeFromArmyDrop.id,
        cached_drop_asset = removeFromArmyDrop,
        force_map_mode = MetaType.Army,
        click_power_action = (pTile, pPower) => _targetArmy != null ? AssetManager.powers.spawnDrops(pTile, pPower) : TryGetArmy(pTile, pPower),
        click_power_brush_action = AssetManager.powers.loopWithCurrentBrushPowerForDropsFull
      };

      return removeFromArmy;
    }

    private static Army _targetArmy;
    private static bool TryGetArmy(WorldTile pTile = null, GodPower _ = null) {
      Army targetArmy = Finder.getUnitsFromChunk(pTile, 1).Where(a => a.hasArmy()).Select(a => a.army).FirstOrDefault();
      if (targetArmy == null) return false;
      _targetArmy = targetArmy;
      return true;
    }
    private static void RemoveUnitFromArmyAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile == null) return;
      pTile.doUnits((a) => RemoveUnitFromArmy(a));
      if (World.world.drop_manager._drops.Where(d => d._asset?.id == pDropID).Count(d => !d._landed) <= 1) {
        _targetArmy = null;
      }
    }
    private static void RemoveUnitFromArmy(Actor actor, bool animate = true) {
      if (_targetArmy == null) return;
      if (actor == null) return;
      actor.removeFromArmy();

      if (animate) {
        actor.startShake();
        actor.startColorEffect();
      }
    }
  }
}
