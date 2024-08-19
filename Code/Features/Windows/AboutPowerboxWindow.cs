using NeoModLoader.General;
using PowerBox.Code.LoadingSystem;
using PowerBox.Code.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Windows {
  public class AboutPowerboxWindow : Feature {
    internal override bool Init() {
      ScrollWindow aboutPowerBoxWindow = WindowCreator.CreateEmptyWindow("aboutPowerBox", "about_powerbox");
      aboutPowerBoxWindow.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().setKeyAndUpdate("about_powerbox");
      aboutPowerBoxWindow.gameObject.transform.Find("Background/Title").GetComponent<LocalizedText>().autoField = false;
      aboutPowerBoxWindow.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);
      GameObject aboutPowerBoxContent = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/aboutPowerBox/Background/Scroll View/Viewport/Content");
      string description = System.Text.Encoding.Default.GetString(AssetUtils.LoadEmbeddedResource("description.txt"));
      GameObject name = aboutPowerBoxWindow.transform.Find("Background").Find("Name").gameObject;
      Text nameText = name.GetComponent<Text>();
      nameText.text = description;
      nameText.color = new Color(0, 0.74f, 0.55f, 1);
      nameText.fontSize = 7;
      nameText.alignment = TextAnchor.UpperLeft;
      nameText.supportRichText = true;
      name.transform.SetParent(aboutPowerBoxWindow.transform.Find("Background").Find("Scroll View").Find("Viewport").Find("Content"));
      name.SetActive(true);
      RectTransform nameRect = name.GetComponent<RectTransform>();
      nameRect.anchorMin = new Vector2(0.5f, 1);
      nameRect.anchorMax = new Vector2(0.5f, 1);
      nameRect.offsetMin = new Vector2(-90f, nameText.preferredHeight * -1);
      nameRect.offsetMax = new Vector2(90f, -17);
      nameRect.sizeDelta = new Vector2(180, nameText.preferredHeight + 50);
      aboutPowerBoxContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, nameText.preferredHeight + 50);
      name.transform.localPosition = new Vector2(name.transform.localPosition.x, ((nameText.preferredHeight / 2) + 30) * -1);
      return true;
    }
  }
}