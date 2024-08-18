using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.GodPowers {
  public class UnitSpawnPowers : Feature {

    internal override bool Init() {
      GodPower burgerSpider = new GodPower {
        id = "spawnBurgerSpider",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        name = "spawnBurgerSpider",
        spawnSound = "spawnAnt",
        actor_asset_id = "burgerSpider",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
      AssetManager.powers.add(burgerSpider);

      GodPower maximCreature = new GodPower {
        id = "spawnMaximCreature",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        name = "spawnMaximCreature",
        spawnSound = "spawnHuman",
        actor_asset_id = "MaximCreature",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
      AssetManager.powers.add(maximCreature);

      GodPower mastefCreature = new GodPower {
        id = "spawnMastefCreature",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        name = "spawnMastefCreature",
        spawnSound = "spawnHuman",
        actor_asset_id = "MastefCreature",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
      AssetManager.powers.add(mastefCreature);
      
      GodPower gregCreature = new GodPower {
        id = "spawnGregCreature",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        name = "spawnGregCreature",
        spawnSound = "spawnHuman",
        actor_asset_id = "greg",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
      AssetManager.powers.add(gregCreature);
      
      GodPower tumorCreatureUnit = new GodPower {
        id = "spawnTumorCreatureUnit",
        name = "spawnTumorCreatureUnit",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        spawnSound = "Tumor_Spawn01",
        actor_asset_id = "tumor_monster_unit",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
      AssetManager.powers.add(tumorCreatureUnit);

      GodPower tumorCreatureAnimal = new GodPower {
        id = "spawnTumorCreatureAnimal",
        name = "spawnTumorCreatureAnimal",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        spawnSound = "Tumor_Spawn01",
        actor_asset_id = "tumor_monster_animal",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
      AssetManager.powers.add(tumorCreatureAnimal);
      
      GodPower mushCreatureUnit = new GodPower {
        id = "spawnMushCreatureUnit",
        name = "spawnMushCreatureUnit",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        spawnSound = "spawnZombie",
        actor_asset_id = "mush_unit",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
      AssetManager.powers.add(mushCreatureUnit);
      
      GodPower mushCreatureAnimal = new GodPower {
        id = "spawnMushCreatureAnimal",
        name = "spawnMushCreatureAnimal",
        rank = PowerRank.Rank0_free,
        unselectWhenWindow = true,
        showSpawnEffect = true,
        actorSpawnHeight = 3f,
        spawnSound = "spawnZombie",
        actor_asset_id = "mush_animal",
        click_action = (pTile, pPower) => AssetManager.powers.spawnUnit(pTile, pPower)
      };
      AssetManager.powers.add(mushCreatureAnimal);
      
      return true;
    }
  }
}