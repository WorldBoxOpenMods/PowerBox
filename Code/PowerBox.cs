using System;
using NeoModLoader.api;
using NeoModLoader.General;
using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Scheduling;
using UnityEngine;

// All v1.3.0 TODOs
// https://canary.discord.com/channels/522561390330904585/1232422556301000764/1232436899239559228
// https://canary.discord.com/channels/522561390330904585/1232422556301000764/1232437262000722040
// https://canary.discord.com/channels/522561390330904585/1232422556301000764/1232443140628283462
// https://canary.discord.com/channels/522561390330904585/1232422556301000764/1232472765827911731
// https://canary.discord.com/channels/522561390330904585/1232422556301000764/1232457071518154762

// All v1.3.1 TODOs
// TODO: https://canary.discord.com/channels/522561390330904585/1232422556301000764/1237407958803939400
// TODO: https://canary.discord.com/channels/522561390330904585/1232422556301000764/1234635618634436670
// TODO: make favorite items persistent, see https://canary.discord.com/channels/@me/1188525491297194044/1235623580402978886 for method
// TODO: https://canary.discord.com/channels/522561390330904585/1232422556301000764/1241195995824390204
// TODO: https://canary.discord.com/channels/522561390330904585/1232422556301000764/1241282748132622357

// Later version TODOs
// TODO: refactor GameWindows/EditItemsWindow.cs
// TODO: https://canary.discord.com/channels/522561390330904585/1232422556301000764/1236953743434448906
// TODO: window for viewing every creature in a world

namespace PowerBox.Code {
  public class PowerBox : BasicMod<PowerBox> {
    protected override void OnModLoad() {
      try {
        DisableLocaleLogs();
      } catch (MissingFieldException) {
        // this is fine
      }
      Debug.Log("Loading PowerBox...");
      FeatureManager.Instance.Init();
      Debug.Log("PowerBox loaded!");
    }
    
    private static void DisableLocaleLogs() {
      // this needs to be a separate method so that a potential MissingFieldException can be caught
      Config.disableLocaleLogs = true;
    }

    #region CollectionMod compatibility
    private bool _lateInitDone;
    private short _lateInitCounter;
    #endregion
    private void Update() {
      #region CollectionMod compatibility
      if (!_lateInitDone) {
        if (_lateInitCounter++ == 120) {
          _lateInitDone = true;
          GameObject cmVillageResourceButton = ResourcesFinder.FindResource<GameObject>("openResourceWindow_dej");
          if (cmVillageResourceButton != null) cmVillageResourceButton.transform.localPosition = new Vector3(cmVillageResourceButton.transform.localPosition.x, cmVillageResourceButton.transform.localPosition.y - 40.0f, cmVillageResourceButton.transform.localPosition.z);
        }
      }
      #endregion
      Scheduler.Instance.Run();
    }
  }
}