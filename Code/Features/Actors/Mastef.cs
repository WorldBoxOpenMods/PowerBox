using System.Collections.Generic;
using NeoModLoader.api;
using NeoModLoader.api.features;

namespace PowerBox.Code.Features.Actors {
  public class Mastef : ModAssetFeature<ActorAsset> {
    public override ModFeatureRequirementList RequiredModFeatures => new[] { typeof(NameGenerators.Mastef), typeof(Maxim) };
    protected override bool AddToLibrary => false;
    protected override ActorAsset InitObject() {
      ActorAsset mastefCreature = AssetManager.actor_library.clone("powerbox_mastef", GetFeature<Maxim>().Object.id);
      mastefCreature.icon = "iconMastefCreature";
      mastefCreature.texture_id = "t_MastefCreature";
      mastefCreature.civ = false;
      mastefCreature.shadow = false;
      mastefCreature.traits = new List<string> {
        "immortal",
        "blessed",
        "fast"
      };
      mastefCreature.name_template_unit = GetFeature<NameGenerators.Mastef>().Object.id;
      return mastefCreature;
    }
  }
}
