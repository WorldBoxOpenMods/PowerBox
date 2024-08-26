using System;
using System.Collections.Generic;
using System.Linq;
using PowerBox.Code.Features.Windows;
using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;

namespace PowerBox.Code.Features.Drops {
  public class CommonItemDrop : AssetFeature<DropAsset> {
    protected override DropAsset InitObject() {
      return new DropAsset {
        id = "powerbox_change_items",
        path_texture = "drops/drop_fireworks",
        animated = true,
        animation_speed = 0.03f,
        default_scale = 0.1f,
        action_landed = ItemChangeAction
      };
    }

    private static void ItemChangeAction(WorldTile pTile = null, string pDropID = null) {
      if (EditItemsWindow.Instance is null) {
        return;
      }
      MapBox.instance.getObjectsInChunks(pTile, 4, MapObjectType.Actor);
      List<BaseSimObject> tempMapObjects = MapBox.instance.temp_map_objects;
      foreach (Actor tempMapObject in tempMapObjects.Cast<Actor>().Where(tempMapObject => tempMapObject.base_data.alive && tempMapObject.asset.use_items)) {
        switch (EditItemsWindow.Instance.PowType) {
          case PowerType.Add: {
            foreach (ItemData data in EditItemsWindow.ChosenForAddSlots.Where(data => data.Value != null).Select(pr => pr.Value.Clone())) {
              data.modifiers = data.modifiers.Where(mod => mod != null).Where(mod => mod != "").Where(mod => mod != "normal").ToList();
              EquipmentType slotType = AssetManager.items.get(data.id).equipmentType;
              ActorEquipmentSlot unitSlot = tempMapObject.equipment.getSlot(slotType);
              if (unitSlot.data != null) {
                if (!EditItemsWindow.CompareItems(data, unitSlot.data)) {
                  unitSlot.setItem(data);
                }
              } else {
                unitSlot.setItem(data);
              }
              tempMapObject.setStatsDirty();
            }
            break;
          }
          case PowerType.Remove: {
            foreach (KeyValuePair<EquipmentType, ItemData> pr in EditItemsWindow.ChosenForRemoveSlots) {
              ItemData data = pr.Value;
              if (data == null) continue;
              EquipmentType slotType = AssetManager.items.get(data.id).equipmentType;
              ActorEquipmentSlot unitSlot = tempMapObject.equipment.getSlot(slotType);
              if (unitSlot.data != null) {
                if (EditItemsWindow.CompareItems(data, unitSlot.data)) {
                  unitSlot.emptySlot();
                }
              }
              tempMapObject.setStatsDirty();
            }
            break;
          }
          case PowerType.Unset:
          default:
            throw new ArgumentOutOfRangeException();
        }

        tempMapObject.clearSprites();

        tempMapObject.startShake();
        tempMapObject.startColorEffect();
      }
    }

  }
}
