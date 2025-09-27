using System.Collections.Generic;
using System.Linq;
using NeoModLoader.api;
using NeoModLoader.General.UI.Tab;
using NeoModLoader.api.features;
using NeoModLoader.General;
using PowerBox.Code.Features.Prefabs;
using PowerBox.Code.Utils;
using UnityEngine;

namespace PowerBox.Code.Features.Buttons {
  public enum TabSection {
    All,
    Info,
    Spawns,
    Metas,
  }
  public class PowerboxTab : ModPowerTabFeature {
    public override ModFeatureRequirementList RequiredModFeatures => base.RequiredModFeatures + typeof(TabSpacer);

    private readonly Dictionary<TabSection, List<PowerButton>> _sectionButtons = new Dictionary<TabSection, List<PowerButton>>();
    private readonly Dictionary<TabSection, List<ModButtonFeature<PowerboxTab>>> _sectionButtonFeatures = new Dictionary<TabSection, List<ModButtonFeature<PowerboxTab>>>();
    protected override PowersTab InitObject() {
      PowersTab tab = TabManager.CreateTab("PowerBox", "powerbox_tab", "powerbox_tab_desc", AssetUtils.LoadEmbeddedSprite("powers/tabIcon"));
      PowerButtonCreator.CreateSimpleButton("powerbox_info_section_button", () => SwitchSection(TabSection.Info), AssetUtils.LoadEmbeddedSprite("powers/flags"), tab.transform);
      PowerButtonCreator.CreateSimpleButton("powerbox_spawns_section_button", () => SwitchSection(TabSection.Spawns), AssetUtils.LoadEmbeddedSprite("powers/spawn_section"), tab.transform);
      PowerButtonCreator.CreateSimpleButton("powerbox_metas_section_button", () => SwitchSection(TabSection.Metas), Resources.Load<Sprite>("ui/icons/iconbrowse1"), tab.transform);
      UnityEngine.Object.Instantiate(GetFeature<TabSpacer>().Prefab, tab.transform);
      return tab;
    }
    public override bool PositionButton(PowerButton button) {
      bool display = false;
      foreach (KeyValuePair<TabSection, List<ModButtonFeature<PowerboxTab>>> section in _sectionButtonFeatures.Where(section => section.Value.Any(f => f.Object == button))) {
        if (!_sectionButtons.ContainsKey(section.Key)) {
          _sectionButtons[section.Key] = new List<PowerButton>();
        }
        _sectionButtons[section.Key].Add(button);
        if (section.Key == TabSection.All) {
          display = true;
        }
      }
      button.gameObject.SetActive(display);
      return true;
    }
    public void RegisterFeatureForTabSection(ModButtonFeature<PowerboxTab> feature, TabSection section) {
      if (!_sectionButtonFeatures.ContainsKey(section)) {
        _sectionButtonFeatures[section] = new List<ModButtonFeature<PowerboxTab>>();
      }
      _sectionButtonFeatures[section].Add(feature);
    }

    public void SwitchSection(TabSection section) {
      World.world.selected_buttons.unselectAll();
      foreach (KeyValuePair<TabSection, List<PowerButton>> sectionButtons in _sectionButtons) {
        foreach (PowerButton button in sectionButtons.Value) {
          if (sectionButtons.Key == TabSection.All) {
            button.gameObject.SetActive(true);
          } else if (sectionButtons.Key != section && button.gameObject.activeSelf) {
            button.gameObject.SetActive(false);
          } else if (sectionButtons.Key == section && !button.gameObject.activeSelf) {
            button.gameObject.SetActive(true);
          }
        }
      }
    }
  }
  
  public abstract class PowerboxButtonFeature : ModButtonFeature<PowerboxTab> {
    protected abstract TabSection Section { get; }
    public override bool Init() {
      GetFeature<PowerboxTab>().RegisterFeatureForTabSection(this, Section);
      base.Init();
      return true;
    }
  }
  public abstract class PowerboxGodPowerButtonFeature<TGodPowerFeature> : ModGodPowerButtonFeature<TGodPowerFeature, PowerboxTab> where TGodPowerFeature : ModAssetFeature<GodPower> {
    protected abstract TabSection Section { get; }
    public override bool Init() {
      GetFeature<PowerboxTab>().RegisterFeatureForTabSection(this, Section);
      base.Init();
      return true;
    }
  }
  public abstract class PowerboxWindowButtonFeature<TWindowFeature> : ModWindowButtonFeature<TWindowFeature, PowerboxTab> where TWindowFeature : ModObjectFeature<ScrollWindow> {
    protected abstract TabSection Section { get; }
    public override bool Init() {
      GetFeature<PowerboxTab>().RegisterFeatureForTabSection(this, Section);
      base.Init();
      return true;
    }
  }
}
