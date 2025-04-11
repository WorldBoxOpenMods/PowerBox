namespace PowerBox.Code.Utils {
  public static class WhisperUtils {
    public static void ResetWhisperKingdoms() {
      Config.whisper_A = null;
      Config.whisper_B = null;
    }

    public static bool TryResetWhisperKingdoms() {
      ResetWhisperKingdoms();
      return true;
    }
  }
}
