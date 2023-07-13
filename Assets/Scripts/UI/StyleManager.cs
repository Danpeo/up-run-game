using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class StyleManager : MonoBehaviour
    {
        [SerializeField] private CommonStyle _currentStyle;
        [SerializeField] private Camera[] _cameras;
        [SerializeField] private Text[] _titles;
        [SerializeField] private Text[] _mainTexts;
        [SerializeField] private Text[] _secondaryTexts;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            ApplyStyle();
        }

        public void ApplyStyle()
        {
            foreach (var camera in _cameras)
            {
                camera.backgroundColor = _currentStyle.MainCameraBackgroundColor;
            }

            foreach (var mainText in _mainTexts)
            {
                mainText.color = _currentStyle.MainTextColor;
            }

            foreach (var secondaryText in _secondaryTexts)
            {
                secondaryText.color = _currentStyle.SecondaryTextColor;
            }

            foreach (var title in _titles)
            {
                title.color = _currentStyle.TitleColor;
                title.font = _currentStyle.TitleFont;
                title.fontSize = _currentStyle.TitleFontSize;
            }
        }
    }
}
