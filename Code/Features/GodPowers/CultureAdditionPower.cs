using System.Linq;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class CultureAdditionPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset addToCultureDrop = new DropAsset {
        id = "powerbox_add_unit_to_culture",
        path_texture = "drops/drop_unity",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = AddUnitToCultureAction
      };
      AssetManager.drops.add(addToCultureDrop);
      
      GodPower addToCulture = new GodPower {
        id = addToCultureDrop.id,
        name = addToCultureDrop.id,
        showToolSizes = true,
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        dropID = addToCultureDrop.id,
        force_map_text = MapMode.Cultures,
        click_power_action = (pTile, pPower) => _targetCulture != null ? AssetManager.powers.spawnDrops(pTile, pPower) : TryGetCulture(pTile, pPower),
        click_power_brush_action = AssetManager.powers.loopWithCurrentBrushPower
      };

      return addToCulture;
    }
    
    private static Culture _targetCulture;
    private static bool TryGetCulture(WorldTile pTile = null, GodPower _ = null) {
      if (pTile?.zone == null) return false;
      _targetCulture = pTile.zone.culture;
      return true;
    }
    private static void AddUnitToCultureAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile == null) return;
      pTile.doUnits((a) => AddUnitToCulture(a));
      if (World.world.dropManager._drops.Where(d => d._asset.id == pDropID).Count(d => !d._landed) <= 1) {
        _targetCulture = null;
      }
    }
    private static void AddUnitToCulture(Actor actor, bool animate = true) {
      if (_targetCulture == null) return;
      if (actor == null) return;
      actor.setCulture(_targetCulture);

      if (animate) {
        actor.startShake();
        actor.startColorEffect();
      }
    }
  }
}
