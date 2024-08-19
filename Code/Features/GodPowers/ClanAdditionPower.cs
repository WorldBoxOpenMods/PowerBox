using System.Linq;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class ClanAdditionPower : Feature {
    internal override bool Init() {
      GodPower addToClan = new GodPower {
        id = "addToClan",
        name = "addToClan",
        showToolSizes = true,
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        dropID = "addToClan",
        force_map_text = MapMode.Clans,
        click_power_action = (pTile, pPower) => _targetClan != null ? AssetManager.powers.spawnDrops(pTile, pPower) : TryGetClan(pTile, pPower),
        click_power_brush_action = AssetManager.powers.loopWithCurrentBrushPower
      };
      AssetManager.powers.add(addToClan);

      DropAsset addToClanDrop = new DropAsset {
        id = "addToClan",
        path_texture = "drops/drop_friendship",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = AddUnitToClanAction
      };
      AssetManager.drops.add(addToClanDrop);

      return true;
    }
    
    private static Clan _targetClan;
    private static bool TryGetClan(WorldTile pTile = null, GodPower _ = null) {
      if (pTile?.zone == null) return false;
      _targetClan = pTile.zone.getClanOnZone();
      return true;
    }
    private static void AddUnitToClanAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile == null) return;
      pTile.doUnits((a) => AddUnitToClan(a));
      if (World.world.dropManager._drops.Where(d => d._asset.id == pDropID).Count(d => !d._landed) <= 1) {
        _targetClan = null;
      }
    }
    private static void AddUnitToClan(Actor actor, bool animate = true) {
      if (_targetClan == null) return;
      if (actor == null) return;
      if (!actor.kingdom.isCiv() || actor.kingdom != _targetClan.getChief()?.kingdom) return;
      if (actor.hasClan()) {
        actor.getClan().removeUnit(actor.data);
      }
      _targetClan.addUnit(actor);

      if (animate) {
        actor.startShake();
        actor.startColorEffect();
      }
    }
  }
}