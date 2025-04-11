using System;
using System.Collections.Generic;
using System.Linq;
using NeoModLoader.api;
using NeoModLoader.api.features;
using UnityEngine;

namespace PowerBox.Code.Features.GodPowers {
  public class BurgerSpiderCloudSpawnPower : ModAssetFeature<GodPower> {
    public override ModFeatureRequirementList RequiredModFeatures => new List<Type> {typeof(BurgerSpiderSpawnPower)};

    protected override GodPower InitObject() {
      DropAsset burgerSpiderCloudDrop = new DropAsset {
        id = "powerbox_cloud_burger_spider",
        path_texture = "drops/drop_blood",
        random_frame = true,
        default_scale = 0.2f,
        sound_drop = "event:/SFX/DROPS/DropRain",
        material = "mat_world_object_lit",
        type = DropType.DropMagic,
        falling_height = new Vector2(30f, 45f),
        action_landed = BurgerSpiderSpawnAction
      };
      AssetManager.drops.add(burgerSpiderCloudDrop);

      CloudAsset burgerSpiderCloud = new CloudAsset {
        id = burgerSpiderCloudDrop.id,
        color = new Color(0.82f, 0.45f, 0.10f, 0.77f),
        drop_id = burgerSpiderCloudDrop.id,
        cloud_action_1 = CloudLibrary.dropAction,
        path_sprites = List.Of("effects/clouds/cloud_big_1", "effects/clouds/cloud_big_2", "effects/clouds/cloud_big_3").ToArray(),
        speed_max = 4f
      };
      AssetManager.clouds.add(burgerSpiderCloud);

      GodPower spawnBurgerSpiderCloud = new GodPower {
        id = "powerbox_spawn_burger_spider_cloud",
        name = "powerbox_spawn_burger_spider_cloud",
        force_brush = "circ_0",
        falling_chance = 0.03f,
        hold_action = true,
        show_tool_sizes = false,
        unselect_when_window = true,
        click_power_action = (pTile, pPower) => EffectsLibrary.spawn("fx_cloud", pTile, burgerSpiderCloud.id)
      };

      burgerSpiderCloud.cached_sprites = burgerSpiderCloud.path_sprites.Select(SpriteTextureLoader.getSprite).Where(sprite => sprite != null).ToArray();
      return spawnBurgerSpiderCloud;
    }

    private void BurgerSpiderSpawnAction(WorldTile pTile = null, string pDropID = null) {
      GetFeature<BurgerSpiderSpawnPower>().Object.click_action(pTile, GetFeature<BurgerSpiderSpawnPower>().Object.id);
    }
  }
}
