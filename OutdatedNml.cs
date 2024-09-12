using NeoModLoader.api;
using UnityEngine;

namespace PowerBox {
  public class OutdatedNml : MonoBehaviour, IMod {
    private ModDeclare _modDeclare;
    private GameObject _gameObject;
    public ModDeclare GetDeclaration() {
      return _modDeclare;
    }
    public GameObject GetGameObject() {
      return _gameObject;
    }
    public string GetUrl() {
      return "https://github.com/WorldBoxOpenMods/PowerBox";
    }
    public void OnLoad(ModDeclare pModDecl, GameObject pGameObject) {
      _modDeclare = pModDecl;
      _gameObject = pGameObject;
      Debug.LogError("You're using an outdated NML version that doesn't support precompiled mods. Please get version 1.0.9 of NeoModLoader or later.");
    }
  }
}
