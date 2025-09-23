using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class ArmyAdditionPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset addToArmyDrop = new DropAsset {
        id = "powerbox_add_unit_to_army",
        path_texture = "drops/drop_unity",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = AddUnitToArmyAction
      };
      AssetManager.drops.add(addToArmyDrop);

      GodPower addToArmy = new GodPower {
        id = addToArmyDrop.id,
        name = addToArmyDrop.id,
        show_tool_sizes = true,
        falling_chance = 0.03f,
        hold_action = true,
        unselect_when_window = true,
        drop_id = addToArmyDrop.id,
        cached_drop_asset = addToArmyDrop,
        force_map_mode = MetaType.Army,
        click_power_action = (pTile, pPower) => _targetArmy != null ? AssetManager.powers.spawnDrops(pTile, pPower) : TryGetArmy(pTile, pPower),
        click_power_brush_action = AssetManager.powers.loopWithCurrentBrushPowerForDropsFull
      };

      return addToArmy;
    }

    private static Army _targetArmy;
    private static bool TryGetArmy(WorldTile pTile = null, GodPower _ = null) {
      Army targetArmy = Finder.getUnitsFromChunk(pTile, 1).Where(a => a.hasArmy()).Select(a => a.army).FirstOrDefault();
      if (targetArmy == null) return false;
      _targetArmy = targetArmy;
      return true;
    }
    private static void AddUnitToArmyAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile == null) return;
      pTile.doUnits((a) => AddUnitToArmy(a));
      if (World.world.drop_manager._drops.Where(d => d._asset?.id == pDropID).Count(d => !d._landed) <= 1) {
        _targetArmy = null;
      }
    }
    private static void AddUnitToArmy(Actor actor, bool animate = true) {
      if (_targetArmy == null) return;
      if (actor == null) return;
      actor.setArmy(_targetArmy);
      actor.setProfession(UnitProfession.Warrior);

      if (animate) {
        actor.startShake();
        actor.startColorEffect();
      }
    }
  }
}
