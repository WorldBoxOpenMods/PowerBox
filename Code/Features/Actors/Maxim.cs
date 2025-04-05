using System.Collections.Generic;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Actors {
  public class Maxim : ModAssetFeature<ActorAsset> {
    public override ModFeatureRequirementList RequiredModFeatures => new[] { typeof(Kingdoms.Developers), typeof(NameGenerators.Maxim) };
    protected override bool AddToLibrary => false;
    protected override ActorAsset InitObject() {
      ActorAsset maximCreature = AssetManager.actor_library.clone("powerbox_maxim", SA.white_mage);
      maximCreature.base_stats[S.lifespan] = 1000;
      maximCreature.icon = "iconMaximCreature";
      maximCreature.kingdom_id_wild = GetFeature<Kingdoms.Developers>().Object.id;
      maximCreature.civ = false;
      maximCreature.has_advanced_textures = false;
      maximCreature.unit_other = true;
      maximCreature.can_attack_buildings = false;
      maximCreature.can_turn_into_zombie = false;
      maximCreature.can_be_moved_by_powers = true;
      maximCreature.can_be_killed_by_stuff = true;
      maximCreature.can_receive_traits = true;
      maximCreature.can_be_hurt_by_powers = true;
      maximCreature.shadow = false;
      maximCreature.texture_id = "t_MaximCreature";
      maximCreature.addSubspeciesTrait("diet_cannibalism");
      maximCreature.base_stats[S.damage] = 100;
      maximCreature.base_stats[S.health] = 1000;
      maximCreature.use_items = false;
      maximCreature.default_weapons = null;
      maximCreature.source_meat = false;
      maximCreature.source_meat_insect = false;
      maximCreature.traits = new List<string> {
        "immortal",
        "blessed",
        "wise"
      };
      maximCreature.name_template_unit = GetFeature<NameGenerators.Maxim>().Object.id;
      maximCreature.texture_asset = null;
      AssetManager.actor_library.loadTexturesAndSprites(maximCreature);
      return maximCreature;
    }
  }
}
