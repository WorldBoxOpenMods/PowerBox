using UnityEngine;

namespace PowerBox.Code {
  public static class MapIconAssets {
    internal static void Init() {

      AssetManager.map_icons.add(new MapIconAsset {
        id = "whisper_of_alliance_line",
        id_prefab = "p_mapArrow_line",
        base_scale = 0.5f,
        draw_call = DrawWhisperOfAllianceLine,
        render_on_map = true,
        render_in_game = true,
        color = new Color(0.4f, 0.4f, 1f, 0.9f)
      });
      AssetManager.map_icons.add(new MapIconAsset {
        id = "whisper_of_peace_line",
        id_prefab = "p_mapArrow_line",
        base_scale = 0.5f,
        draw_call = DrawWhisperOfPeaceLine,
        render_on_map = true,
        render_in_game = true,
        color = new Color(0.4f, 0.4f, 1f, 0.9f)
      });
    }

    private static void DrawWhisperOfAllianceLine(MapIconAsset pAsset) {
      if (!Input.mousePresent || World.world.isBusyWithUI() || !World.world.isSelectedPower("create_alliance")) {
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
    
    private static void DrawWhisperOfPeaceLine(MapIconAsset pAsset) {
      if (!Input.mousePresent || World.world.isBusyWithUI() || !World.world.isSelectedPower("friendshipNR")) {
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