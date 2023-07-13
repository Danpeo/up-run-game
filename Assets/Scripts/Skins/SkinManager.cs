using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Skins
{
    public class SkinManager : MonoBehaviour
    {
        [SerializeField] private SkinData _skinData;
        [SerializeField] private Text _skinName;
        [SerializeField] private Image _skinImage;
        private int _selectedOption;

        private void Start()
        {
            SetCurrentSkin();
            DontDestroyOnLoad(gameObject);
        }

        public void OnNextSkin()
        {
            _selectedOption++;
            
            if (_selectedOption >= _skinData.SkinLength)
                _selectedOption = 0;
            
            UpdateSkin(_selectedOption);
        }

        public void OnPrevSkin()
        {
            _selectedOption--;

            if (_selectedOption < 0)
                _selectedOption = _skinData.SkinLength - 1;
            
            UpdateSkin(_selectedOption);
        }

        private void UpdateSkin(int selectedOption)
        {
            var skin = _skinData.GetSkin(selectedOption);
            _skinImage.sprite = skin.SkinImage.sprite;
            _skinName.text = skin.SkinName;
        }
        
        private void Load()
        {
            _selectedOption = PlayerPrefs.GetInt("SelectedSkin", 0);
        }
        
        public void Save()
        {
            _skinData.CurrentSkin = _skinData.GetSkin(_selectedOption).Prefab;
            PlayerPrefs.SetInt("SelectedSkin", _selectedOption);
            PlayerPrefs.Save();
        }
        
        public void SetCurrentSkin()
        {
            Load();
            UpdateSkin(_selectedOption);
        }
    }
}