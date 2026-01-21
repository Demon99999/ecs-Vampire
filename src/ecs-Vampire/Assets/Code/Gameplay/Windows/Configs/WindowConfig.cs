using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Code.Gameplay.Windows.Configs
{
  [Serializable]
  public class WindowConfig
  {
    [SerializeField] private WindowId _id;
    [SerializeField] private GameObject _prefab;
    
    public WindowId Id => _id;

    public GameObject Prefab => _prefab;
  }
}