using System.Collections.Generic;
using System.Linq;
using NeoModLoader.api;
using PowerBox.Code.Features.Prefabs;
using strings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PowerBox.Code.Features.UiHelpers {
  public class UnitButtonCreator : ModFeature {
    public override ModFeatureRequirementList RequiredModFeatures => base.RequiredModFeatures + typeof(UnitAvatarElement);

    public override bool Init() {
      return true;
    }

    public void CreateUnitButton(Actor unit, int index, GameObject content) {
      if (unit?.asset is null) {
        return;
      }
      GameObject unitInfo = new GameObject {
        name = $"unit_{index}_info",
        transform = {
          parent = content.transform,
          // ReSharper disable once PossibleLossOfFraction
          localPosition = new Vector3(30.0f + 40 * (index % 5), 10.0f + index / 5 * -40.0f, 0.0f),
          localScale = new Vector3(0.9f, 0.9f, 0.9f)
        }
      };
      GameObject unitInfoAvatarGameObject = Object.Instantiate(GetFeature<UnitAvatarElement>().Prefab, unitInfo.transform);
      UiUnitAvatarElement unitInfoAvatar = unitInfoAvatarGameObject.GetComponent<UiUnitAvatarElement>();
      unitInfoAvatar.Start();
      unitInfoAvatar.show(unit);
      unitInfoAvatarGameObject.name = $"unit_{index}_avatar";
      unitInfoAvatarGameObject.transform.localPosition = new Vector3(0.0f, -10.0f, 0.0f);
      List<GameObject> objectsToCheck = new List<GameObject> {unitInfo};
      {
        GameObject go;
        // ReSharper disable once AssignmentInConditionalExpression
        while (go = objectsToCheck.FirstOrDefault()) {
          objectsToCheck.Remove(go);
          objectsToCheck.AddRange(from Transform child in go.transform select child.gameObject);
          Button gob = go.GetComponent<Button>();
          if (gob != null) {
            for (int i = 0; i < gob.onClick.GetPersistentEventCount(); i++) {
              gob.onClick.SetPersistentListenerState(i, UnityEventCallState.Off);
            }
            gob.onClick.RemoveAllListeners();
          }
        }
      }
      Button unitInfoButton = unitInfoAvatarGameObject.AddComponent<Button>();
      unitInfoButton.onClick.AddListener(() => {
        if (!unit.isAlive() || !World.world.units.getSimpleList().Contains(unit)) {
          return;
        }
        SelectedUnit.select(unit);
        ScrollWindow.showWindow(S_Window.unit);
      });
      unitInfoAvatar.gameObject.SetActive(true);
    }
  }
}
