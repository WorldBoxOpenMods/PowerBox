using System.Collections.Generic;
using System.Linq;
using NeoModLoader.api;
using NeoModLoader.api.features;
using UnityEngine;

namespace PowerBox.Code.Features.GodPowers {
  public class BloodRainCloudSpawnPower : ModAssetFeature<GodPower> {
    protected override GodPower InitObject() {
      DropAsset bloodRainCloudDrop = new DropAsset {
        id = "powerbox_blood_rain_cloud",
        path_texture = "drops/drop_blood",
        random_frame = true,
        default_scale = 0.2f,
        sound_drop = "fallingWater",
        falling_height = new Vector2(30f, 45f),
        action_landed = DropsLibrary.action_blood_rain
      };
      AssetManager.drops.add(bloodRainCloudDrop);

      CloudAsset bloodRainCloud = new CloudAsset {
        id = bloodRainCloudDrop.id,
        color = new Color(0.76f, 0.09f, 0.09f, 0.77f),
        drop_id = bloodRainCloudDrop.id,
        cloud_action_1 = CloudLibrary.dropAction,
        path_sprites = List.Of("effects/clouds/cloud_big_1", "effects/clouds/cloud_big_2", "effects/clouds/cloud_big_3").ToArray(),
        speed_max = 4f
      };
      AssetManager.clouds.add(bloodRainCloud);
      
      DropAsset bloodRainPowerDrop = new DropAsset {
        id = "powerbox_spawn_blood_rain_cloud",
        path_texture = "drops/drop_blood",
        random_frame = true,
        default_scale = 0.2f,
        sound_drop = "fallingWater",
        falling_height = new Vector2(0f, 0f),
        action_landed = (pTile, pDropID) => EffectsLibrary.spawn("fx_cloud", pTile: pTile, pParam1: bloodRainCloud.id)
      };
      AssetManager.drops.add(bloodRainPowerDrop);
      
      GodPower spawnBloodRainCloud = new GodPower {
        id = bloodRainPowerDrop.id,
        name = bloodRainPowerDrop.id,
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = true,
        show_tool_sizes = false,
        unselect_when_window = true,
        drop_id = bloodRainPowerDrop.id,
        click_power_action = (pTile, pPower) => AssetManager.powers.spawnDrops(pTile, pPower)
      };

      bloodRainCloud.cached_sprites = bloodRainCloud.path_sprites.Select(SpriteTextureLoader.getSprite).Where(sprite => sprite != null).ToArray();
      return spawnBloodRainCloud;
    }
  }
}
