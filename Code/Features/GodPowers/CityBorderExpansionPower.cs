using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class CityBorderExpansionPower : Feature {
    internal override bool Init() {
      GodPower expandCitiesBorders = new GodPower {
        id = "expandCitiesBorders",
        name = "expandCitiesBorders",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CityBorderExpansionAction
      };
      AssetManager.powers.add(expandCitiesBorders);
      return true;
    }
    
    private static City _toCityZone;
    private static bool CityBorderExpansionAction(WorldTile pTile = null, string pPowerId = null) {
      if (pTile?.zone.city != null) {
        _toCityZone = pTile.zone.city;
      } else {
        if (pTile != null) _toCityZone?.addZone(pTile.zone);
      }
      return true;
    }
  }
}