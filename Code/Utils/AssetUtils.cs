using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace PowerBox.Code.Utils {
  public static class AssetUtils {
    /// <summary>
    /// Loads the byte contents of a file from the EmbeddedResources directory of PowerBox.
    /// </summary>
    /// <param name="path">A path pointing to a file in the EmbeddedResources directory of PowerBox, in the form of e.g. actors/maxim_spider.png. The path to EmbeddedResources is automatically appended.</param>
    /// <returns>The bytes stored at that path. Throws an exception if literally anything goes wrong in this process (there's 0 exception handling present).</returns>
    public static byte[] LoadEmbeddedResource(string path) {
      return File.ReadAllBytes(PowerBox.Instance.GetDeclaration().FolderPath + "/EmbeddedResources/" + path);
    }
    /// <summary>
    /// Loads a sprite from a PNG from the EmbeddedResources directory of PowerBox.
    /// </summary>
    /// <param name="path">A path pointing to a PNG in the EmbeddedResources directory of PowerBox, in the form of e.g. actors/maxim_spider. The path to EmbeddedResources and the .png are automatically appended.</param>
    /// <returns>A Sprite representing the PNG file loaded at that path. Throws an exception if literally anything goes wrong in this process (there's 0 exception handling present).</returns>
    public static Sprite LoadEmbeddedSprite(string path) {
      Texture2D spriteTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false) {
        anisoLevel = 0,
        filterMode = FilterMode.Point
      };
      spriteTexture.LoadImage(LoadEmbeddedResource(path + ".png"));
      return Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), new Vector2(0.5f, 0.5f));
    }
    /// <summary>
    /// Creates a clone of the given object via Reflection.
    /// </summary>
    /// <param name="original">The object to clone.</param>
    /// <param name="deep">Whether or not field/property values of the object should be cloned recursively.</param>
    /// <typeparam name="T">The type of the object to clone. Must have a public constructor without params.</typeparam>
    /// <returns>A clone of the specified object.</returns>
    public static T Clone<T>(this T original, bool deep = false) where T : new() {
      T clone = new T();
      foreach (FieldInfo field in original.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
        if (deep && !field.FieldType.IsPrimitive) {
          field.SetValue(clone, field.GetValue(original).Clone());
        } else {
          field.SetValue(clone, field.GetValue(original));
        }
      }
      foreach (PropertyInfo prop in original.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(prop => prop.CanWrite && prop.CanRead)) {
        if (deep && !prop.PropertyType.IsPrimitive) {
          prop.SetValue(clone, prop.GetValue(original).Clone());
        } else {
          prop.SetValue(clone, prop.GetValue(original));
        }
      }
      return clone;
    }
  }
}