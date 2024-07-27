using NeoModLoader.General;
using PowerBox.Code.GameWindows;
using PowerBox.Code.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code {
  internal static class Windows {
    internal static FindFavouriteItemsWindow FindFavouriteItemsWindow;
    internal static EditItemsWindow EditItemsWindow;
    internal static EditResourcesWindow EditResourcesWindow;
    internal static FindCultureMembersWindow FindCultureMembersWindow;
    internal static EditCultureTechWindow EditCultureTechWindow;
    internal static EditFavoriteFoodWindow EditFavoriteFoodWindow;

    internal static void Init() {
      #region FindFavouriteItemsWindow
      FindFavouriteItemsWindow = new FindFavouriteItemsWindow();
      #endregion
      
      #region aboutPowerBoxWindow

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

      #endregion


      #region EditItemsWindow

      ScrollWindow.checkWindowExist("inspect_unit");

      GameObject inspectUnitObject = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/inspect_unit");
      Transform inspectUnitContent = inspectUnitObject.transform.Find("/Canvas Container Main/Canvas - Windows/windows/inspect_unit/Background");
      inspectUnitObject.SetActive(false);

      EditItemsWindow = new EditItemsWindow(inspectUnitContent);

      #endregion


      #region EditResoucesWindow

      ScrollWindow.checkWindowExist("village");
      GameObject inspectVillage = ResourcesFinder.FindResource<GameObject>("village");
      inspectVillage.SetActive(false);
      Transform inspectVillageBackground = inspectVillage.transform.Find("Background");

      EditResourcesWindow = new EditResourcesWindow(inspectVillageBackground);

      #endregion
      
      #region FindCultureMembersWindow
      ScrollWindow.checkWindowExist("culture");

      GameObject cultureObject = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/culture");
      Transform cultureContent = cultureObject.transform.Find("/Canvas Container Main/Canvas - Windows/windows/culture/Background");
      cultureObject.SetActive(false);

      FindCultureMembersWindow = new FindCultureMembersWindow(cultureContent);

      #endregion
      
      #region EditCultureTechWindow
      
      cultureObject.SetActive(false);

      EditCultureTechWindow = new EditCultureTechWindow(cultureContent);

      #endregion
      
      #region EditFavoriteFoodWindow
      ScrollWindow.checkWindowExist("inspect_unit");
      
      EditFavoriteFoodWindow = new EditFavoriteFoodWindow();
      #endregion
      
      #region EditFavoriteFoodWindow
      ScrollWindow.checkWindowExist("inspect_unit");
      
      EditFavoriteFoodWindow = new EditFavoriteFoodWindow();
      #endregion
    }
  }
}