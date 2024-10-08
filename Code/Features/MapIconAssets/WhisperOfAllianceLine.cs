using PowerBox.Code.LoadingSystem;
using UnityEngine;

namespace PowerBox.Code.Features.MapIconAssets {
  public class WhisperOfAllianceLine : AssetFeature<MapIconAsset> {
    internal override FeatureRequirementList RequiredFeatures => typeof(GodPowers.AllianceCreationPower);
    protected override MapIconAsset InitObject() {
      return new MapIconAsset {
        id = "powerbox_whisper_of_alliance_line",
        id_prefab = "p_mapArrow_line",
        base_scale = 0.5f,
        draw_call = DrawWhisperOfAllianceLine,
        render_on_map = true,
        render_in_game = true,
        color = new Color(0.4f, 0.4f, 1f, 0.9f)
      };
    }
    
    private void DrawWhisperOfAllianceLine(MapIconAsset pAsset) {
      if (!Input.mousePresent || World.world.isBusyWithUI() || !World.world.isSelectedPower(GetFeature<GodPowers.AllianceCreationPower>().Object.id)) {
        return;
      }
      Kingdom whisperA = Config.whisperA;
      if (whisperA == null) {
        return;
      }
      Vector2 mousePos = World.world.getMousePos();
      foreach (City city in whisperA.cities) {
        Color pColor = whisperA.getColor().getColorMain2();
        MapIconLibrary.drawArrowMark(pAsset, city.getTile().posV, mousePos, ref pColor);
      }
    }
  }
}
