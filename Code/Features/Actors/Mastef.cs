using System.Collections.Generic;
using PowerBox.Code.LoadingSystem;

namespace PowerBox.Code.Features.Actors {
  public class Mastef : AssetFeature<ActorAsset> {
    internal override FeatureRequirementList RequiredFeatures => new[] { typeof(NameGenerators.Mastef), typeof(Maxim) };
    protected override bool AddToLibrary => false;
    protected override ActorAsset InitObject() {
      ActorAsset mastefCreature = AssetManager.actor_library.clone("powerbox_mastef", GetFeature<Maxim>().Object.id);
      mastefCreature.icon = "iconMastefCreature";
      mastefCreature.texture_path = "t_MastefCreature";
      mastefCreature.unit = false;
      mastefCreature.shadow = false;
      mastefCreature.traits = new List<string> {
        "immortal",
        "blessed",
        "fast"
      };
      mastefCreature.nameTemplate = GetFeature<NameGenerators.Mastef>().Object.id;
      return mastefCreature;
    }
  }
}
