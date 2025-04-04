using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using NeoModLoader.api;
using PowerBox.Code.Features.Windows;
namespace PowerBox.Code.Features.Patches {
  public class PreventSettingActorToNullInUiUnitAvatarOnDisablePatch : ModFeature {
    public override ModFeatureRequirementList RequiredModFeatures => base.RequiredModFeatures + typeof(Harmony);
    public override bool Init() {
      GetFeature<Harmony>().Instance.Patch(
        AccessTools.Method(typeof(UiUnitAvatarElement), nameof(UiUnitAvatarElement.OnDisable)),
        transpiler: new HarmonyMethod(typeof(FindAllCreaturesWindow), nameof(UiUnitAvatarElement_OnDisable_PreventSettingActorToNull))
      );
      return true;
    }

    private static IEnumerable<CodeInstruction> UiUnitAvatarElement_OnDisable_PreventSettingActorToNull(IEnumerable<CodeInstruction> instructions) {
      foreach (CodeInstruction instruction in instructions) {
        if (instruction.opcode == OpCodes.Ldnull) {
          yield return new CodeInstruction(OpCodes.Ldarg_0);
          yield return new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(UiUnitAvatarElement), nameof(UiUnitAvatarElement._actor)));
        } else {
          yield return instruction;
        }
      }
    }
  }
}
