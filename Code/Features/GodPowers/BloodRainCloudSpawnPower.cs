using System.Linq;
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
        sound_drop = "event:/SFX/DROPS/DropRain",
        material = "mat_world_object_lit",
        type = DropType.DropMagic,
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

      GodPower spawnBloodRainCloud = new GodPower {
        id = "powerbox_spawn_blood_rain_cloud",
        name = "powerbox_spawn_blood_rain_cloud",
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = true,
        show_tool_sizes = false,
        unselect_when_window = true,
        drop_id = "powerbox_spawn_blood_rain_cloud",
        click_power_action = (pTile, pPower) => EffectsLibrary.spawn("fx_cloud", pTile, bloodRainCloud.id)
      };

      bloodRainCloud.cached_sprites = bloodRainCloud.path_sprites.Select(SpriteTextureLoader.getSprite).Where(sprite => sprite != null).ToArray();
      return spawnBloodRainCloud;
    }
  }
}
