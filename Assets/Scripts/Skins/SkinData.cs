using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Skins
{
    [CreateAssetMenu(menuName = "Data/SkinData", fileName = "SkinData")]
    [Serializable]
    public class SkinData : ScriptableObject
    {
        [SerializeField] private Skin[] _skins;
        public GameObject CurrentSkin;
        public int SkinLength => _skins.Length;
        
        public Skin GetSkin(int index) => _skins[index];
        
        [Serializable]
        public struct Skin
        {
            public string SkinName;
            public Image SkinImage;
            public GameObject Prefab;
        }
    }
}
