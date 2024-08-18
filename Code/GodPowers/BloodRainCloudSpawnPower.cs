using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;
using UnityEngine;

namespace PowerBox.Code.GodPowers {
  public class BloodRainCloudSpawnPower : Feature {

    internal override bool Init() {
      
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
        action_landed = CloudUtils.CloudSpawnAction
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
      return true;
    }
  }
}