using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.GodPowers {
  public class CultureDuplicationPower : Feature {
    internal override bool Init() {
      GodPower duplicateCulture = new GodPower {
        id = "duplicateCulture",
        name = "createCulture",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = false,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CultureDuplicationAction
      };
      AssetManager.powers.add(duplicateCulture);
      return true;
    }
    
    private static bool CultureDuplicationAction(WorldTile pTile = null, string pPowerId = null) {
      City targetCity = pTile?.zone?.city;
      Culture oldCulture = targetCity?.getCulture();
      if (oldCulture == null) return false;
      Culture newCulture = World.world.cultures.newCulture(targetCity.race, targetCity);
      oldCulture._list_tech.ForEach(t => newCulture.addFinishedTech(t.id));
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