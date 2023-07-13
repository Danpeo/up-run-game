using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components.Animation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimationComponent : MonoBehaviour
    {
        [SerializeField][Range(1,120)] private int _frameRate = 10;
        [SerializeField] private UnityEvent<string> _onComplete;
        [SerializeField] private AnimationClip[] _clips;
        
        private SpriteRenderer _renderer;
        private float _secondsPerFrame;
        private int _currentFrame;
        private float _nextFrameTime;
        private bool _isPlaying = true;
        public int CurrentClip { get; set; }

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _secondsPerFrame = 1f / _frameRate;
            StartAnimation();
        }

        private void Update()
        {
            if (_nextFrameTime > Time.time) return;

            var clip = _clips[CurrentClip];

            if (_currentFrame >= clip.Sprites.Length)
            {
                if (clip.Loop)
                {
                    _currentFrame = 0;
                }
                else
                {
                    enabled = _isPlaying = clip.AllowNextClip;
                    clip.OnComplete?.Invoke();
                    _onComplete?.Invoke(clip.Name);

                    if (clip.AllowNextClip)
                    {
                        _currentFrame = 0;
                        CurrentClip = (int)Mathf.Repeat(CurrentClip + 1, _clips.Length);
                    }
                }
                return;
            }

            _renderer.sprite = clip.Sprites[_currentFrame];
            _nextFrameTime += _secondsPerFrame;
            _currentFrame++;
        }
        
        /*private void OnBecameVisible()
        {
            enabled = _isPlaying;
        }

        private void OnBecameInvisible()
        {
            enabled = false;
        }*/

        public void SetClip(string clipName)
        {
            for (int i = 0; i < _clips.Length; i++)
            {
                if (_clips[i].Name == clipName)
                {
                    CurrentClip = i;
                    StartAnimation();
                    return;
                }
            }

            enabled = _isPlaying = false;
        }

        private void StartAnimation()
        {
            _nextFrameTime = Time.time;
            enabled = _isPlaying = true;
            _currentFrame = 0;
        }
        
        private void OnEnable()
        {
            _nextFrameTime = Time.time;
        }
    }
}
