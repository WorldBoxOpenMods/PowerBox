using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.GodPowers {
  public class BurgerSpiderCloudSpawnPower : AssetFeature<GodPower> {
    internal override FeatureRequirementList RequiredFeatures => new List<Type> { typeof(BurgerSpiderSpawnPower) };

    protected override GodPower InitObject() {
      DropAsset burgerSpiderCloudDrop = new DropAsset {
        id = "powerbox_cloud_burger_spider",
        path_texture = "drops/drop_blood",
        random_frame = true,
        default_scale = 0.2f,
        sound_drop = "fallingWater",
        fallingHeight = new Vector2(30f, 45f),
        action_landed = BurgerSpiderSpawnAction
      };
      AssetManager.drops.add(burgerSpiderCloudDrop);

      CloudAsset burgerSpiderCloud = new CloudAsset {
        id = burgerSpiderCloudDrop.id,
        color = new Color(0.82f, 0.45f, 0.10f, 0.77f),
        drop_id = burgerSpiderCloudDrop.id,
        cloud_action_1 = CloudLibrary.dropAction,
        path_sprites = List.Of("effects/clouds/cloud_big_1", "effects/clouds/cloud_big_2", "effects/clouds/cloud_big_3"),
        speed_max = 4f
      };
      AssetManager.clouds.add(burgerSpiderCloud);

      DropAsset burgerSpiderPowerDrop = new DropAsset {
        id = "powerbox_spawn_burger_spider_cloud",
        path_texture = "drops/drop_blood",
        random_frame = true,
        default_scale = 0.2f,
        sound_drop = "fallingWater",
        fallingHeight = new Vector2(0f, 0f),
        action_landed = (pTile, pDropID) => EffectsLibrary.spawn("fx_cloud", pTile, pParam1: burgerSpiderCloud.id)
      };
      AssetManager.drops.add(burgerSpiderPowerDrop);
      
      GodPower spawnBurgerSpiderCloud = new GodPower {
        id = burgerSpiderPowerDrop.id,
        name = burgerSpiderPowerDrop.id,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        dropID = burgerSpiderPowerDrop.id,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };

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
