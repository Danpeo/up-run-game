using System;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class HighScoreText : MonoBehaviour
    {
        [SerializeField] private string _message = string.Empty;
        private Text _highScoreText;
        private ScoreCounter _scoreCounter;
        
        private void Awake()
        {
            _highScoreText = GetComponent<Text>();
            _scoreCounter = FindObjectOfType<ScoreCounter>();
        }

        private void Start()
        {
            _highScoreText.text = $"{_message}{_scoreCounter.HighScore}";
        }

        private void OnEnable()
        {
            _scoreCounter.OnHighScoreChanged += UpdateHighScoreText;
        }

        private void OnDestroy()
        {
            _scoreCounter.OnHighScoreChanged -= UpdateHighScoreText;
        }

        private void UpdateHighScoreText(int score)
        {
            _highScoreText.text = $"{_message}{score}";
        }
    }
}