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
  public class Tab : ModPowerTabFeature {
    public override ModFeatureRequirementList RequiredModFeatures => base.RequiredModFeatures + typeof(TabSpacer);

    private readonly Dictionary<TabSection, List<PowerButton>> _sectionButtons = new Dictionary<TabSection, List<PowerButton>>();
    private readonly Dictionary<TabSection, List<ModButtonFeature<Tab>>> _sectionButtonFeatures = new Dictionary<TabSection, List<ModButtonFeature<Tab>>>();
    private readonly GameObject _unusedButtonPit;
    private int _createdButtons;
    private const float StartX = 72f;
    private const float PlusX = 18f;
    private const float EvenY = 18f;
    private const float OddY = -18f;

    public Tab() {
      _unusedButtonPit = new GameObject("PowerBox_UnusedButtons");
      UnityEngine.Object.DontDestroyOnLoad(_unusedButtonPit);
      _unusedButtonPit.SetActive(false);
    }
    protected override PowersTab InitObject() {
      PowersTab tab = TabManager.CreateTab("PowerBox", "powerbox_tab", "powerbox_tab_desc", AssetUtils.LoadEmbeddedSprite("powers/tabIcon"));
      PowerButtonCreator.CreateSimpleButton("powerbox_info_section_button", () => SwitchSection(TabSection.Info), AssetUtils.LoadEmbeddedSprite("powers/flags"), tab.transform);
      PowerButtonCreator.CreateSimpleButton("powerbox_spawns_section_button", () => SwitchSection(TabSection.Spawns), AssetUtils.LoadEmbeddedSprite("powers/spawn_section"), tab.transform);
      PowerButtonCreator.CreateSimpleButton("powerbox_metas_section_button", () => SwitchSection(TabSection.Metas), Resources.Load<Sprite>("ui/icons/iconbrowse1"), tab.transform);
      UnityEngine.Object.Instantiate(GetFeature<TabSpacer>().Prefab, tab.transform);
      return tab;
    }
    public override bool PositionButton(PowerButton button) {
      float x = StartX + (_createdButtons != 0 ? PlusX * (_createdButtons % 2 == 0 ? _createdButtons : _createdButtons - 1) : 0);
      float y = _createdButtons % 2 == 0 ? EvenY : OddY;
      button.transform.localPosition = new Vector3(x, y);
      _createdButtons++;
      bool display = false;
      foreach (KeyValuePair<TabSection, List<ModButtonFeature<Tab>>> section in _sectionButtonFeatures.Where(section => section.Value.Any(f => f.Object == button))) {
        if (!_sectionButtons.ContainsKey(section.Key)) {
          _sectionButtons[section.Key] = new List<PowerButton>();
        }
        _sectionButtons[section.Key].Add(button);
        if (section.Key == TabSection.All) {
          display = true;
        }
      }
      button.transform.SetParent(display ? Object.transform : _unusedButtonPit.transform);
      return true;
    }
    public void RegisterFeatureForTabSection(ModButtonFeature<Tab> feature, TabSection section) {
      if (!_sectionButtonFeatures.ContainsKey(section)) {
        _sectionButtonFeatures[section] = new List<ModButtonFeature<Tab>>();
      }
      _sectionButtonFeatures[section].Add(feature);
    }

    public void SwitchSection(TabSection section) {
      World.world.selected_buttons.unselectAll();
      foreach (KeyValuePair<TabSection, List<PowerButton>> sectionButtons in _sectionButtons) {
        foreach (PowerButton button in sectionButtons.Value) {
          if (sectionButtons.Key == TabSection.All) {
            button.transform.SetParent(Object.transform);
          } else if (sectionButtons.Key != section && button.transform.parent != _unusedButtonPit.transform) {
            button.transform.SetParent(_unusedButtonPit.transform);
          } else if (sectionButtons.Key == section && button.transform.parent == _unusedButtonPit.transform) {
            button.transform.SetParent(Object.transform);
          }
        }
      }
    }
  }
  
  public abstract class PowerboxButtonFeature : ModButtonFeature<Tab> {
    public abstract TabSection Section { get; }
    public override bool Init() {
      GetFeature<Tab>().RegisterFeatureForTabSection(this, Section);
      base.Init();
      return true;
    }
  }
  public abstract class PowerboxGodPowerButtonFeature<TGodPowerFeature> : ModGodPowerButtonFeature<TGodPowerFeature, Tab> where TGodPowerFeature : ModAssetFeature<GodPower> {
    public abstract TabSection Section { get; }
    public override bool Init() {
      GetFeature<Tab>().RegisterFeatureForTabSection(this, Section);
      base.Init();
      return true;
    }
  }
  public abstract class PowerboxWindowButtonFeature<TWindowFeature> : ModWindowButtonFeature<TWindowFeature, Tab> where TWindowFeature : ModObjectFeature<ScrollWindow> {
    public abstract TabSection Section { get; }
    public override bool Init() {
      GetFeature<Tab>().RegisterFeatureForTabSection(this, Section);
      base.Init();
      return true;
    }
  }
}
