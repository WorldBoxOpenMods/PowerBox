using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;
using UnityEngine;

namespace PowerBox.Code.GodPowers {
  public class BurgerSpiderCloudSpawnPower : Feature {
    internal override List<Type> RequiredFeatures => new List<Type> { typeof(Actors.BurgerSpider) };

    internal override bool Init() {
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
        action_landed = CloudUtils.CloudSpawnAction
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
      return true;
    }
    
    private static void BurgerSpiderSpawnAction(WorldTile pTile = null, string pDropID = null) {
      GodPower godPower = AssetManager.powers.get("spawnBurgerSpider");
      godPower.click_action(pTile, godPower.id);
    }
  }
}