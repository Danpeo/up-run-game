using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Styles/Common Styles", fileName = "CommonStyle")]
public class CommonStyle : ScriptableObject
{
   [SerializeField] private Color _mainCameraBackGroundColor;
   public Color MainCameraBackgroundColor => _mainCameraBackGroundColor;
   [SerializeField] private Color _mainTextColor;
   public Color MainTextColor => _mainTextColor;
   [SerializeField] private Color _secondaryTextColor;
   public Color SecondaryTextColor => _secondaryTextColor;
   
   [Header("Title")]
   [SerializeField] private Color _titleColor;
   public Color TitleColor => _titleColor;
   [SerializeField] private int _titleFontSize;
   public int TitleFontSize => _titleFontSize;
   [SerializeField] private Font _titleFont;
   public Font TitleFont => _titleFont;
}
