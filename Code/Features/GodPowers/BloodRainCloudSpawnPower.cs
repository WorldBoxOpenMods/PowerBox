using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.GodPowers {
  public class BloodRainCloudSpawnPower : AssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset bloodRainCloudDrop = new DropAsset {
        id = "powerbox_blood_rain_cloud",
        path_texture = "drops/drop_blood",
        random_frame = true,
        default_scale = 0.2f,
        sound_drop = "fallingWater",
        fallingHeight = new Vector2(30f, 45f),
        action_landed = DropsLibrary.action_bloodRain
      };
      AssetManager.drops.add(bloodRainCloudDrop);

      CloudAsset bloodRainCloud = new CloudAsset {
        id = bloodRainCloudDrop.id,
        color = new Color(0.76f, 0.09f, 0.09f, 0.77f),
        drop_id = bloodRainCloudDrop.id,
        cloud_action_1 = CloudLibrary.dropAction,
        path_sprites = List.Of("effects/clouds/cloud_big_1", "effects/clouds/cloud_big_2", "effects/clouds/cloud_big_3"),
        speed_max = 4f
      };
      AssetManager.clouds.add(bloodRainCloud);
      
      DropAsset bloodRainPowerDrop = new DropAsset {
        id = "powerbox_spawn_blood_rain_cloud",
        path_texture = "drops/drop_blood",
        random_frame = true,
        default_scale = 0.2f,
        sound_drop = "fallingWater",
        fallingHeight = new Vector2(0f, 0f),
        action_landed = (pTile, pDropID) => EffectsLibrary.spawn("fx_cloud", pTile: pTile, pParam1: bloodRainCloud.id)
      };
      AssetManager.drops.add(bloodRainPowerDrop);
      
      GodPower spawnBloodRainCloud = new GodPower {
        id = bloodRainPowerDrop.id,
        name = bloodRainPowerDrop.id,
        forceBrush = "circ_0",
        fallingChance = 0.03f,
        holdAction = true,
        showToolSizes = false,
        unselectWhenWindow = true,
        dropID = bloodRainPowerDrop.id,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };

      bloodRainCloud.cached_sprites = new List<Sprite>();
      foreach (Sprite sprite in bloodRainCloud.path_sprites.Select(SpriteTextureLoader.getSprite).Where(sprite => sprite != null)) {
        bloodRainCloud.cached_sprites.Add(sprite);
      }
      return spawnBloodRainCloud;
    }
  }
}
