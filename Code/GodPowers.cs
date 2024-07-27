using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.GameWindows;
using PowerBox.Code.Utils;
using UnityEngine;

namespace PowerBox.Code {
  internal static class GodPowers {
    internal static void Init() {
      #region UnitSpawnPowers

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

      #endregion


      #region ItemAdditionPower

      GodPower addItems = new GodPower {
        id = "addItems",
        holdAction = true,
        showToolSizes = true,
        unselectWhenWindow = true,
        name = "addItems",
        dropID = "change_items",
        fallingChance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPower(pTile, pPower)
      };
      AssetManager.powers.add(addItems);

      #endregion


      #region ItemRemovalPower

      GodPower removeItems = new GodPower {
        id = "removeItems",
        holdAction = true,
        showToolSizes = true,
        unselectWhenWindow = true,
        name = "removeItems",
        dropID = "change_items",
        fallingChance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPower(pTile, pPower)
      };
      AssetManager.powers.add(removeItems);

      #endregion


      #region CommonItemDrop

      DropAsset changeItemsDrop = new DropAsset {
        id = "change_items",
        path_texture = "drops/drop_fireworks",
        animated = true,
        animation_speed = 0.03f,
        default_scale = 0.1f,
        action_landed = ItemChangeAction
      };
      AssetManager.drops.add(changeItemsDrop);

      #endregion


      #region FriendshipPower

      GodPower friendshipNotRandom = new GodPower() {
        id = "friendshipNR",
        name = "friendshipNR",
        force_map_text = MapMode.Kingdoms,
        select_button_action = _ => !TryResetWhisperKingdoms(),
        click_special_action = NonRandomFriendshipAction
      };
      AssetManager.powers.add(friendshipNotRandom);

      #endregion


      #region ClanAdditionPower

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

      #endregion


      #region BuildingUpgradePower

      GodPower upgradeBuildingAdd = new GodPower {
        id = "upgradeBuildingAdd",
        holdAction = true,
        showToolSizes = true,
        unselectWhenWindow = true,
        name = "upgradeBuildingAdd",
        dropID = "upgradeBuildingAdd",
        fallingChance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPower(pTile, pPower)
      };
      AssetManager.powers.add(upgradeBuildingAdd);


      DropAsset upgradeBuildingAddDrop = new DropAsset {
        id = "upgradeBuildingAdd",
        path_texture = "drops/drop_snow",
        animated = true,
        animation_speed = 0.03f,
        default_scale = 0.1f,
        action_landed = BuildingUpgradeAction
      };
      AssetManager.drops.add(upgradeBuildingAddDrop);

      #endregion


      #region BuildingDowngradePower

      GodPower downgradeBuildingAdd = new GodPower {
        id = "downgradeBuildingAdd",
        holdAction = true,
        showToolSizes = true,
        unselectWhenWindow = true,
        name = "downgradeBuildingAdd",
        dropID = "downgradeBuildingAdd",
        fallingChance = 0.01f,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower),
        click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPower(pTile, pPower)
      };
      AssetManager.powers.add(downgradeBuildingAdd);


      DropAsset downgradeBuildingAddDrop = new DropAsset {
        id = "downgradeBuildingAdd",
        path_texture = "drops/drop_snow",
        animated = true,
        animation_speed = 0.03f,
        default_scale = 0.1f,
        action_landed = BuildingDowngradeAction
      };
      AssetManager.drops.add(downgradeBuildingAddDrop);

      #endregion


      #region ColonyCreationPower

      GodPower makeColony = new GodPower {
        id = "makeColony",
        name = "makeColony",
        showToolSizes = false,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        dropID = "makeColony",
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      AssetManager.powers.add(makeColony);


      DropAsset makeColonyDrop = new DropAsset {
        id = "makeColony",
        path_texture = "drops/drop_gold",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = ColonyCreationAction
      };
      AssetManager.drops.add(makeColonyDrop);

      #endregion


      #region CityBorderExpansionPower

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

      #endregion


      #region CityBorderReductionPower

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

      #endregion


      #region CultureBorderExpansionPower

      GodPower expandCultureBorders = new GodPower {
        id = "expandCultureBorders",
        name = "expandCultureBorders",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CultureBorderExpansionAction
      };
      AssetManager.powers.add(expandCultureBorders);

      #endregion


      #region CultureBorderReductionPower

      GodPower reduceCultureBorders = new GodPower {
        id = "reduceCultureBorders",
        name = "reduceCultureBorders",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CultureBorderReductionAction
      };
      AssetManager.powers.add(reduceCultureBorders);

      #endregion


      #region CultureCreationPower

      GodPower createCulture = new GodPower {
        id = "createCulture",
        name = "createCulture",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = false,
        showToolSizes = false,
        unselectWhenWindow = true,
        click_special_action = CultureCreationAction
      };
      AssetManager.powers.add(createCulture);
      
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


      #endregion


      #region CultureAdditionPower

      GodPower addToCulture = new GodPower {
        id = "addToCulture",
        name = "addToCulture",
        showToolSizes = true,
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        dropID = "addToCulture",
        force_map_text = MapMode.Cultures,
        click_power_action = (pTile, pPower) => _targetCulture != null ? AssetManager.powers.spawnDrops(pTile, pPower) : TryGetCulture(pTile, pPower),
        click_power_brush_action = AssetManager.powers.loopWithCurrentBrushPower
      };
      AssetManager.powers.add(addToCulture);

      DropAsset addToCultureDrop = new DropAsset {
        id = "addToCulture",
        path_texture = "drops/drop_friendship",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = AddUnitToCultureAction
      };
      AssetManager.drops.add(addToCultureDrop);

      #endregion


      #region BloodRainCloudSpawnPower

      GodPower spawnBloodRainCloud = new GodPower {
        id = "bloodRainCloudSpawn",
        name = "bloodRainCloudSpawn",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        dropID = "cloudBloodRainD",
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      AssetManager.powers.add(spawnBloodRainCloud);

      DropAsset cloudBloodRainD = new DropAsset {
        id = "cloudBloodRainD",
        path_texture = "drops/drop_blood",
        random_frame = true,
        default_scale = 0.2f,
        sound_drop = "fallingWater",
        fallingHeight = new Vector2(0f, 0f),
        action_landed = CloudSpawnAction
      };
      AssetManager.drops.add(cloudBloodRainD);

      DropAsset cloudBloodRain = new DropAsset {
        id = "cloudBloodRain",
        path_texture = "drops/drop_blood",
        random_frame = true,
        default_scale = 0.2f,
        sound_drop = "fallingWater",
        fallingHeight = new Vector2(30f, 45f),
        action_landed = DropsLibrary.action_bloodRain
      };
      AssetManager.drops.add(cloudBloodRain);

      CloudAsset bloodRainCloud = new CloudAsset {
        id = "cloud_blood_rain",
        color = new Color(0.76f, 0.09f, 0.09f, 0.77f),
        drop_id = "cloudBloodRain",
        cloud_action_1 = CloudLibrary.dropAction,
        path_sprites = List.Of("effects/clouds/cloud_big_1", "effects/clouds/cloud_big_2", "effects/clouds/cloud_big_3"),
        speed_max = 4f
      };
      AssetManager.clouds.add(bloodRainCloud);

      bloodRainCloud.cached_sprites = new List<Sprite>();
      foreach (Sprite sprite in bloodRainCloud.path_sprites.Select(SpriteTextureLoader.getSprite).Where(sprite => sprite != null)) {
        bloodRainCloud.cached_sprites.Add(sprite);
      }

      #endregion


      #region BurgerSpiderCloudSpawnPower

      GodPower spawnBurgerSpiderCloud = new GodPower {
        id = "burgerSpiderCloudSpawn",
        name = "burgerSpiderCloudSpawn",
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        dropID = "cloudBurgerSpiderD",
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      AssetManager.powers.add(spawnBurgerSpiderCloud);

      DropAsset cloudBurgerSpiderD = new DropAsset {
        id = "cloudBurgerSpiderD",
        path_texture = "drops/drop_blood",
        random_frame = true,
        default_scale = 0.2f,
        sound_drop = "fallingWater",
        fallingHeight = new Vector2(0f, 0f),
        action_landed = CloudSpawnAction
      };
      AssetManager.drops.add(cloudBurgerSpiderD);

      DropAsset cloudBurgerSpider = new DropAsset {
        id = "cloudBurgerSpider",
        path_texture = "drops/drop_blood",
        random_frame = true,
        default_scale = 0.2f,
        sound_drop = "fallingWater",
        fallingHeight = new Vector2(30f, 45f),
        action_landed = BurgerSpiderSpawnAction
      };
      AssetManager.drops.add(cloudBurgerSpider);

      CloudAsset burgerSpiderCloud = new CloudAsset {
        id = "cloud_burger_spider",
        color = new Color(0.82f, 0.45f, 0.10f, 0.77f),
        drop_id = "cloudBurgerSpider",
        cloud_action_1 = CloudLibrary.dropAction,
        path_sprites = List.Of("effects/clouds/cloud_big_1", "effects/clouds/cloud_big_2", "effects/clouds/cloud_big_3"),
        speed_max = 4f
      };
      AssetManager.clouds.add(burgerSpiderCloud);

      burgerSpiderCloud.cached_sprites = new List<Sprite>();
      foreach (Sprite sprite in burgerSpiderCloud.path_sprites.Select(SpriteTextureLoader.getSprite).Where(sprite => sprite != null)) {
        burgerSpiderCloud.cached_sprites.Add(sprite);
      }

      #endregion


      #region BoatSpawnPowers

      GodPower spawnTradingBoat = new GodPower {
        id = "spawn_boat_trading",
        name = "spawn_boat_trading",
        showSpawnEffect = true,
        showToolSizes = false,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        actor_asset_id = "boat_trading",
        dropID = "spawn_boat_trading",
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      AssetManager.powers.add(spawnTradingBoat);

      DropAsset spawnTradingBoatDrop = new DropAsset {
        id = "spawn_boat_trading",
        path_texture = "drops/drop_metal",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = (pTile, pDropID) => BoatSpawnAction(pTile, "boat_trading"),
        material = "mat_world_object_lit",
        sound_drop = "event:/SFX/DROPS/DropRainGamma"
      };
      AssetManager.drops.add(spawnTradingBoatDrop);


      GodPower spawnTransportBoat = new GodPower {
        id = "spawn_boat_transport",
        name = "spawn_boat_transport",
        showSpawnEffect = true,
        showToolSizes = false,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        actor_asset_id = "boat_transport",
        dropID = "spawn_boat_transport",
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      AssetManager.powers.add(spawnTransportBoat);

      DropAsset spawnTransportBoatDrop = new DropAsset {
        id = "spawn_boat_transport",
        path_texture = "drops/drop_metal",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = (pTile, pDropID) => BoatSpawnAction(pTile, "boat_transport"),
        material = "mat_world_object_lit",
        sound_drop = "event:/SFX/DROPS/DropRainGamma"
      };
      AssetManager.drops.add(spawnTransportBoatDrop);


      GodPower spawnFishingBoat = new GodPower {
        id = "spawn_boat_fishing",
        name = "spawn_boat_fishing",
        showSpawnEffect = true,
        showToolSizes = false,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        unselectWhenWindow = true,
        actor_asset_id = "boat_fishing",
        dropID = "spawn_boat_fishing",
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };
      AssetManager.powers.add(spawnFishingBoat);

      DropAsset spawnFishingBoatDrop = new DropAsset {
        id = "spawn_boat_fishing",
        path_texture = "drops/drop_metal",
        random_frame = true,
        default_scale = 0.1f,
        action_landed = (pTile, pDropID) => BoatSpawnAction(pTile, "boat_fishing"),
        material = "mat_world_object_lit",
        sound_drop = "event:/SFX/DROPS/DropRainGamma"
      };
      AssetManager.drops.add(spawnFishingBoatDrop);

      #endregion

      
      #region AllianceCreationPower

      GodPower createAlliance = new GodPower() {
        id = "create_alliance",
        name = "create_alliance",
        force_map_text = MapMode.Kingdoms,
        select_button_action = _ => !TryResetWhisperKingdoms(),
        click_special_action = AllianceCreationAction
      };
      AssetManager.powers.add(createAlliance);

      #endregion
    }
    
    private static void ResetWhisperKingdoms() {
      Config.whisperA = null;
      Config.whisperB = null;
    }
    
    private static bool TryResetWhisperKingdoms() {
      ResetWhisperKingdoms();
      return true;
    }


    #region NonRandomFriendshipAction

    private static bool NonRandomFriendshipAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile?.zone.city == null)
        return false;

      Kingdom kingdom = pTile.zone.city.kingdom;
      
      if (Config.whisperA == null) {
        Config.whisperA = kingdom;
        return false;
      }
      if (Config.whisperA.id == kingdom.id) {
        return false;
      }
      if (!Config.whisperA.isAlive()) {
        Config.whisperA = kingdom;
        return false;
      }
      Config.whisperB = kingdom;
      World.world.wars.list.Where(w => w.isInWarWith(Config.whisperA, Config.whisperB)).ToList().ForEach(w => World.world.wars.endWar(w));
      Config.whisperA = null;
      Config.whisperB = null;
      return true;
    }

    #endregion


    #region AddUnitToClanAction

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

    #endregion


    #region AddUnitToCultureAction

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

    #endregion


    #region BuildingUpgradeAction

    private static void BuildingUpgradeAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile?.building != null && !string.IsNullOrWhiteSpace(pTile.building.asset.upgradeTo)) {
        BuildingAsset pTemplate = AssetManager.buildings.get(pTile.building.asset.upgradeTo);
        pTile.building.city?.setBuildingDictID(pTile.building, false);
        pTile.building.setTemplate(pTemplate);
        pTile.building.city?.setBuildingDictID(pTile.building, true);
        pTile.building.initAnimationData();
        pTile.building.updateStats();
        pTile.building.data.health = pTile.building.getMaxHealth();
        pTile.building.fillTiles();
      }
    }

    #endregion


    #region BuildingDowngradeAction

    private static void BuildingDowngradeAction(WorldTile pTile = null, string pDropID = null) {
      if (pTile?.building != null) {
        BuildingAsset pTemplate = AssetManager.buildings.list.FirstOrDefault(asset => asset.upgradeTo == pTile.building.asset.id);
        if (pTemplate != null) {
          pTile.building.city?.setBuildingDictID(pTile.building, false);
          pTile.building.setTemplate(pTemplate);
          pTile.building.city?.setBuildingDictID(pTile.building, true);
          pTile.building.initAnimationData();
          pTile.building.updateStats();
          pTile.building.data.health = pTile.building.getMaxHealth();
          pTile.building.fillTiles();
        }
      }
    }

    #endregion


    #region ColonyCreationAction

    private static void ColonyCreationAction(WorldTile pTile = null, string pDropID = null) {
      MapBox.instance.getObjectsInChunks(pTile, 4, MapObjectType.Actor);
      List<BaseSimObject> tempMapObjects = MapBox.instance.temp_map_objects;

      foreach (Actor tempMapObject in from Actor tempMapObject in tempMapObjects where tempMapObject.base_data.alive && tempMapObject.kingdom.isCiv() let ai = tempMapObject.ai select tempMapObject) {
        tempMapObject.startShake();
        tempMapObject.startColorEffect();

        if (tempMapObject.currentTile.zone.city == null) {
          Kingdom kingdom = tempMapObject.kingdom;
          MapBox world = MapBox.instance;

          TileZone zone = tempMapObject.currentTile.zone;

          if (kingdom != null && kingdom.isNomads())
            kingdom = null;

          Race race = tempMapObject.race;

          City city1 = world.cities.buildNewCity(zone, race, kingdom);

          if (city1 == null)
            return;

          city1.newCityEvent();

          city1.race = race;


          City city2 = tempMapObject.city;
          if (city2 != null) {

            tempMapObject.kingdom.newCityBuiltEvent(city1);
            city2.removeCitizen(tempMapObject);
            tempMapObject.removeFromCity();
          }
          tempMapObject.becomeCitizen(city1);
          WorldLog.logNewCity(city1);
        } else {
          if (pTile != null && tempMapObject.city != pTile.zone.city) {
            tempMapObject.city.removeCitizen(tempMapObject);
            tempMapObject.removeFromCity();
            tempMapObject.becomeCitizen(pTile.zone.city);
            Kingdom kingdomN = pTile.zone.city.kingdom;
            tempMapObject.kingdom = kingdomN;
          }
        }
      }
    }

    #endregion


    #region ItemChangeAction

    private static void ItemChangeAction(WorldTile pTile = null, string pDropID = null) {
      MapBox.instance.getObjectsInChunks(pTile, 4, MapObjectType.Actor);
      List<BaseSimObject> tempMapObjects = MapBox.instance.temp_map_objects;
      foreach (Actor tempMapObject in tempMapObjects.Cast<Actor>().Where(tempMapObject => tempMapObject.base_data.alive && tempMapObject.asset.use_items)) {
        switch (WindowBase.PowType) {
          case PowerType.Add: {
            foreach (ItemData data in EditItemsWindow.ChosenForAddSlots.Where(data => data.Value != null).Select(pr => pr.Value.Clone())) {
              data.modifiers = data.modifiers.Where(mod => mod != null).Where(mod => mod != "").Where(mod => mod != "normal").ToList();
              EquipmentType slotType = AssetManager.items.get(data.id).equipmentType;
              ActorEquipmentSlot unitSlot = tempMapObject.equipment.getSlot(slotType);
              if (unitSlot.data != null) {
                if (!EditItemsWindow.CompareItems(data, unitSlot.data)) {
                  unitSlot.setItem(data);
                }
              } else {
                unitSlot.setItem(data);
              }
              tempMapObject.setStatsDirty();
            }
            break;
          }
          case PowerType.Remove: {
            foreach (KeyValuePair<EquipmentType, ItemData> pr in EditItemsWindow.ChosenForRemoveSlots) {
              ItemData data = pr.Value;
              if (data == null) continue;
              EquipmentType slotType = AssetManager.items.get(data.id).equipmentType;
              ActorEquipmentSlot unitSlot = tempMapObject.equipment.getSlot(slotType);
              if (unitSlot.data != null) {
                if (EditItemsWindow.CompareItems(data, unitSlot.data)) {
                  unitSlot.emptySlot();
                }
              }
              tempMapObject.setStatsDirty();
            }
            break;
          }
          case PowerType.Unset:
          default:
            throw new ArgumentOutOfRangeException();
        }

        tempMapObject.clearSprites();

        tempMapObject.startShake();
        tempMapObject.startColorEffect();
      }
    }

    #endregion


    #region BurgerSpiderSpawnAction

    private static void BurgerSpiderSpawnAction(WorldTile pTile = null, string pDropID = null) {
      GodPower godPower = AssetManager.powers.get("spawnBurgerSpider");
      godPower.click_action(pTile, godPower.id);
    }

    #endregion


    #region CloudSpawnAction

    private static void CloudSpawnAction(WorldTile pTile = null, string pDropID = null) {
      if (pDropID == null)
        return;

      WorldTile random = pDropID.EndsWith("D") ? pTile : MapBox.instance.tilesList.GetRandom();

      if (pDropID.EndsWith("D"))
        pDropID = pDropID.Remove(pDropID.Length - 1, 1);
      CloudAsset cloud;
      switch (pDropID) {
        case "cloudBurgerSpider":
          cloud = AssetManager.clouds.get("cloud_burger_spider");
          break;
        case "cloudBloodRain":
          cloud = AssetManager.clouds.get("cloud_blood_rain");
          break;
        default:
          return;
      }
      EffectsLibrary.spawn("fx_cloud", pTile: random, pParam1: cloud.id);
    }

    #endregion


    #region CityBorderExpansionAction and CityBorderReductionAction

    private static City _toCityZone;
    private static bool CityBorderExpansionAction(WorldTile pTile = null, string pPowerId = null) {
      if (pTile?.zone.city != null) {
        _toCityZone = pTile.zone.city;
      } else {
        if (pTile != null) _toCityZone?.addZone(pTile.zone);
      }
      return true;
    }

    private static bool CityBorderReductionAction(WorldTile pTile = null, string pPowerId = null) {
      pTile?.zone.city?.removeZone(pTile.zone, true);
      return true;
    }

    #endregion


    #region CultureBorderExpansionAction and CultureBorderReductionAction

    private static Culture _toCultureZone;
    private static bool CultureBorderExpansionAction(WorldTile pTile = null, string pPowerId = null) {
      if (pTile?.zone.culture != null) {
        _toCultureZone = pTile.zone.culture;
      } else {
        if (pTile != null) _toCultureZone?.addZone(pTile.zone);
      }
      return true;
    }

    private static bool CultureBorderReductionAction(WorldTile pTile = null, string pPowerId = null) {
      pTile?.zone.culture?.removeZone(pTile.zone);
      return true;
    }

    #endregion


    #region CultureCreationAction

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

    #endregion

    #region CultureDuplicationAction

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

    #endregion


    #region BoatSpawnAction

    private static void BoatSpawnAction(WorldTile pTile, string boatType) {
      if (pTile.zone.city == null)
        return;

      if (!pTile.Type.liquid)
        return;

      Actor actor = MapBox.instance.units.spawnNewUnit(boatType, pTile);

      Kingdom kingdom = pTile.zone.city.kingdom;
      actor.setKingdom(kingdom);
      actor.setCity(pTile.zone.city);
    }

    #endregion

    
    #region AllianceCreationAction

    private static bool AllianceCreationAction(WorldTile pTile, string pPowerID) {
      City city = pTile.zone.city;
      if (city == null) {
        return false;
      }

      Kingdom kingdom = city.kingdom;
      if (Config.whisperA == null) {
        Config.whisperA = kingdom;
        return false;
      }

      if (Config.whisperB == null && Config.whisperA == kingdom) {
        WorldTip.showNow("create_alliance_same_kingdom_selected_twice_error", true, "top");
        return false;
      }

      if (Config.whisperB == null) {
        Config.whisperB = kingdom;
      }

      if (Config.whisperB != Config.whisperA) {

        if (Alliance.isSame(Config.whisperA.getAlliance(), Config.whisperB.getAlliance())) {
          WorldTip.showNow("create_alliance_already_allied_error", true, "top");
          Config.whisperB = null;
          return false;
        }

        foreach (War war in World.world.wars.getWars(Config.whisperA).Where(war => war.isInWarWith(Config.whisperA, Config.whisperB))) {
          war.removeFromWar(Config.whisperA);
          war.removeFromWar(Config.whisperB);
        }

        Alliance allianceA = Config.whisperA.getAlliance();
        Alliance allianceB = Config.whisperB.getAlliance();
        if (allianceA != null) {
          if (allianceB != null) {
            IEnumerable<Kingdom> kingdoms = allianceB.kingdoms_list;
            World.world.alliances.dissolveAlliance(allianceB);
            foreach (Kingdom ally in kingdoms) {
              ForceIntoAlliance(allianceA, ally);
            }
          } else {
            ForceIntoAlliance(allianceA, Config.whisperB);
          }
        } else {
          if (allianceB == null) {
            ForceNewAlliance(Config.whisperA, Config.whisperB);
          } else {
            ForceIntoAlliance(allianceB, Config.whisperA);
          }
        }
        WorldTip.showNow("create_alliance_success", true, "top");
        Config.whisperA = null;
        Config.whisperB = null;
      }

      return true;
    }

    private static void ForceIntoAlliance(Alliance alliance, Kingdom kingdom) {
      alliance.kingdoms_hashset.Add(kingdom);
      kingdom.allianceJoin(alliance);
      alliance.recalculate();
      alliance.data.timestamp_member_joined = World.world.getCurWorldTime();
    }

    private static void ForceNewAlliance(Kingdom kingdomA, Kingdom kingdomB) {
      Alliance alliance = World.world.alliances.newObject();
      alliance.createAlliance();
      alliance.data.founder_kingdom_1 = kingdomA.data.name;
      if (kingdomA.king != null) {
        alliance.data.founder_name_1 = kingdomA.king.getName();
      }
      ForceIntoAlliance(alliance, kingdomA);
      ForceIntoAlliance(alliance, kingdomB);
      WorldLog.logAllianceCreated(alliance);
    }

    #endregion

  }
}