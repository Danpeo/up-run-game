using System;
using Player;
using UnityEngine;

namespace Score
{
    public class ScoreCounter : MonoBehaviour
    {
        private PlayerComponent _player;
        public event Action<int> OnScoreCnanged; 
        
        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                if (_score != value)
                {
                    _score = value;
                    OnScoreCnanged?.Invoke(_score);
                }
            }
        }
        public event Action<int> OnHighScoreChanged;
        private int _highScore;
        public int HighScore
        {
            get => _highScore;
            set
            {
                if (_highScore != value)
                {
                    _highScore = value;
                    OnHighScoreChanged?.Invoke(_highScore);
                }
            }
        }
        
        private int _toppedScore = int.MinValue;
        
        private void Awake()
        {
            _player = FindObjectOfType<PlayerComponent>();
            if (PlayerPrefs.HasKey("HighScore"))
            {
                HighScore = PlayerPrefs.GetInt("HighScore");
            }
        }

        private void Update()
        {
            UpdateScore();
        }

        private void UpdateScore()
        {
            if (_player == null)
                return;
            
            var playerPosition = _player.transform.position;
            var currentScore = (int)(0 + playerPosition.y);

            if (currentScore > _toppedScore)
            {
                _toppedScore = currentScore;
            }

            Score = _toppedScore;
            if (Score > HighScore)
            {
                HighScore = Score;
                UpdateHighScore();
            }
        }

        private void UpdateHighScore()
        {
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();
        }
    }
}
