using NeoModLoader.api;
using NeoModLoader.api.features;
using UnityEngine;

namespace PowerBox.Code.Features.QuantumSpriteAssets {
  public class WhisperOfPeaceLine : ModAssetFeature<QuantumSpriteAsset> {
    public override ModFeatureRequirementList RequiredModFeatures => typeof(GodPowers.NonRandomFriendshipPower);
    protected override QuantumSpriteAsset InitObject() {
      return new QuantumSpriteAsset {
        id = "powerbox_whisper_of_peace_line",
        id_prefab = "p_mapArrow_line",
        base_scale = 0.5f,
        draw_call = DrawWhisperOfPeaceLine,
        render_on_map = true,
        render_in_game = true,
        color = new Color(0.4f, 0.4f, 1f, 0.9f)
      };
    }

    private void DrawWhisperOfPeaceLine(QuantumSpriteAsset pAsset) {
      if (!Input.mousePresent || World.world.isBusyWithUI() || !World.world.isSelectedPower(GetFeature<GodPowers.NonRandomFriendshipPower>().Object.id)) {
        return;
      }
      Kingdom whisperA = Config.whisper_A;
      if (whisperA == null) {
        return;
      }
      Vector2 mousePos = World.world.getMousePos();
      foreach (City city in whisperA.cities) {
        Color pColor = whisperA.getColor().getColorMain2();
        QuantumSpriteLibrary.drawArrowQuantumSprite(pAsset, city.getTile().posV, mousePos, ref pColor);
      }
    }
  }
}
