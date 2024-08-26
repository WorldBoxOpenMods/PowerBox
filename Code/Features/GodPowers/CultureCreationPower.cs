using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class CultureCreationPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      return new GodPower {
        id = "powerbox_create_new_culture",
        name = "powerbox_create_new_culture",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = false,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CultureCreationAction
      };
    }
    
    private static bool CultureCreationAction(WorldTile pTile = null, string pPowerId = null) {
      if (pTile?.zone?.city == null) return false;
      City targetCity = pTile.zone.city;
      Culture newCulture = World.world.cultures.newCulture(targetCity.race, targetCity);
      foreach (TileZone zone in targetCity.zones) {
        newCulture.addZone(zone);
      }
      foreach (Actor actor in targetCity.units) {
        actor.setCulture(newCulture);
      }
      return true;
    }
  }
}
