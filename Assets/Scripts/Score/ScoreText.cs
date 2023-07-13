using System;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class ScoreText : MonoBehaviour
    {
        private Text _scoreText;
        private ScoreCounter _scoreCounter;
        
        private void Awake()
        {
            _scoreText = GetComponent<Text>();
            _scoreCounter = FindObjectOfType<ScoreCounter>();
        }

        private void OnEnable()
        {
            _scoreCounter.OnScoreCnanged += UpdateScoreText;
        }

        private void OnDestroy()
        {
            _scoreCounter.OnScoreCnanged -= UpdateScoreText;
        }

        private void UpdateScoreText(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}
