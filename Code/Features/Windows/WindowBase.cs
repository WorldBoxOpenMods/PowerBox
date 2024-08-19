using PowerBox.Code.LoadingSystem;
using UnityEngine;
using UnityEngine.UI;

namespace PowerBox.Code.Features.Windows {
  public abstract class WindowBase<T> : Feature where T : WindowBase<T> {
    protected ScrollWindow Window { get; set; }
    protected GameObject SpriteHighlighter { get; private set; }
    protected const float Red = 0.314f;
    protected const float Green = 0.78f;
    protected const float Blue = 0;
    protected const float Alpha = 0.565f;

    public static T Instance { get; private set; }
    public WindowBase() {
      Instance = (T)this;
    }

    internal override bool Init() {
      SpriteHighlighter = new GameObject("spriteHighlighter") {
        transform = {
          localScale = new Vector2(1.0f, 1.0f)
        },
        layer = 5
      };
      Image imageH = SpriteHighlighter.AddComponent<Image>();
      Texture2D texture = Resources.Load<Texture2D>("ui/icons/iconbrush_circ_5");
      imageH.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1f);
      imageH.color = new Color(Red, Green, Blue, Alpha);
      imageH.raycastTarget = false;
      SpriteHighlighter.SetActive(false);
      return true;
    }

    protected GameObject AddHighLight(int index, GameObject content, bool enabled = false) {
      GameObject spriteHl = Object.Instantiate(SpriteHighlighter, content.transform);
      spriteHl.transform.localPosition = GetPosByIndex(index);
      spriteHl.SetActive(true);

      spriteHl.GetComponent<Image>().color = enabled ? new Color(Red, Green, Blue, Alpha) : new Color(Red, Green, Blue, 0);

      return spriteHl;
    }

    protected static void HighlightTrait(bool enable, GameObject highLight) {
      highLight.GetComponent<Image>().color = enable ? new Color(Red, Green, Blue, Alpha) : new Color(Red, Green, Blue, 0);
    }

    protected static void HighlightButton(bool enable, GameObject highLight) => HighlightTrait(enable, highLight);

    protected void UnhighlightAll(GameObject content) {
      for (int i = 0; i < content.transform.childCount; i++) {
        HighlightButton(false, content.transform.GetChild(i).gameObject);
      }
    }


    protected float StartXPos = 44.4f;
    protected float XStep = 28f;
    protected int CountInRow = 7;
    protected float StartYPos = -22.5f;
    protected float YStep = -28.5f;
    protected Vector2 GetPosByIndex(int index) {
      float x = (index % CountInRow) * XStep + StartXPos;
      // ReSharper disable once PossibleLossOfFraction
      float y = (index / CountInRow * YStep) + StartYPos;

      return new Vector2(x, y);
    }

    protected void ResetWrapValues() {
      StartXPos = 40f;
      XStep = 22f;
      CountInRow = 9;
      StartYPos = -22.5f;
      YStep = -22.5f;
    }
  }
}