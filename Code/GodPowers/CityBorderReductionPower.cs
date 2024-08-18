using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.GodPowers {
  public class CityBorderReductionPower : Feature {
    internal override bool Init() {
      GodPower reduceCitiesBorders = new GodPower {
        id = "reduceCitiesBorders",
        name = "reduceCitiesBorders",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CityBorderReductionAction
      };
      AssetManager.powers.add(reduceCitiesBorders);
      return true;
    }
    
    private static bool CityBorderReductionAction(WorldTile pTile = null, string pPowerId = null) {
      pTile?.zone.city?.removeZone(pTile.zone, true);
      return true;
    }
  }
}