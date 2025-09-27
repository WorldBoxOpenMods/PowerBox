using System.Linq;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.GodPowers {
  public class ClanAdditionPower : ModAssetFeature<GodPower> {

    private static Clan _targetClan;
    protected override GodPower InitObject() {
      DropAsset addToClanDrop = new DropAsset {
        id = "powerbox_add_unit_to_clan",
        path_texture = "drops/drop_friendship",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = AddUnitToClanAction
      };
      AssetManager.drops.add(addToClanDrop);

      GodPower addToClan = new GodPower {
        id = addToClanDrop.id,
        name = addToClanDrop.id,
        show_tool_sizes = true,
        falling_chance = 0.03f,
        hold_action = true,
        unselect_when_window = true,
        drop_id = addToClanDrop.id,
        cached_drop_asset = addToClanDrop,
        force_map_mode = MetaType.Clan,
        click_power_action = (pTile, pPower) => _targetClan != null ? AssetManager.powers.spawnDrops(pTile, pPower) : TryGetClan(pTile, pPower),
        click_power_brush_action = AssetManager.powers.loopWithCurrentBrushPowerForDropsFull
      };

      return addToClan;
    }
    private static bool TryGetClan(WorldTile pTile = null, GodPower _ = null) {
      if (pTile?.zone == null) return false;
      _targetClan = (pTile.zone.getClanOnZone(0) as Clan ?? pTile.zone.getClanOnZone(1) as Clan) ?? pTile.zone.getClanOnZone(-1) as Clan;
      return true;
    }
    private static void AddUnitToClanAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile == null) return;
      pTile.doUnits(a => AddUnitToClan(a));
      if (World.world.drop_manager._drops.Where(d => d?._asset?.id == pDropID).Count(d => !d._landed) <= 1) {
        _targetClan = null;
      }
    }
    private static void AddUnitToClan(Actor actor, bool animate = true) {
      if (_targetClan == null) return;
      if (actor == null) return;
      if (!actor.kingdom.isCiv() || actor.kingdom != _targetClan.getChief()?.kingdom) return;
      if (actor.hasClan()) {
        actor.clan.units.Remove(actor);
        actor.clan.setUnitStatsDirty();
      }
      _targetClan.units.Add(actor);

      if (animate) {
        actor.startShake();
        actor.startColorEffect();
      }
    }
  }
}
