namespace PowerBox.Code.Utils {
  public static class WhisperUtils {
    public static void ResetWhisperKingdoms() {
      Config.whisperA = null;
      Config.whisperB = null;
    }
    
    public static bool TryResetWhisperKingdoms() {
      ResetWhisperKingdoms();
      return true;
    }
  }
}