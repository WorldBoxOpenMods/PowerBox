using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;
using UnityEngine;

namespace PowerBox.Code.Features.GodPowers {
  public class BurgerSpiderCloudSpawnPower : AssetFeature<GodPower> {
    internal override FeatureRequirementList RequiredFeatures => new List<Type> { typeof(BurgerSpiderSpawnPower) };

    protected override GodPower InitObject() {
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
      return spawnBurgerSpiderCloud;
    }
    
    private void BurgerSpiderSpawnAction(WorldTile pTile = null, string pDropID = null) {
      GetFeature<BurgerSpiderSpawnPower>().Object.click_action(pTile, GetFeature<BurgerSpiderSpawnPower>().Object.id);
    }
  }
}
