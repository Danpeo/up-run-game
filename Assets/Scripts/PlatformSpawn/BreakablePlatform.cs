using System;
using Audio;
using Components.Animation;
using UnityEngine;
using UnityEngine.Events;

namespace PlatformSpawn
{
    public class BreakablePlatform : Platform
    {
        [SerializeField] private int _health = 1;
        [SerializeField] private UnityEvent<GameObject> _onBreak;
        [SerializeField] private SpriteAnimationComponent _spriteAnimation;
        private int _hitClip;
        private PlatformEffector2D _platformEffector;
        private AudioManager _audioManager;

        protected override void Awake()
        {
            base.Awake();
            _audioManager = FindObjectOfType<AudioManager>();
        }

        public void ApplyDamage()
        {
            _health -= 1;
            _hitClip++;
            _spriteAnimation.SetClip($"hit_{_hitClip}");
            
            if (_health <= 0)
            {
                _audioManager.PlayAudioSound("SmallBreak");
                _onBreak?.Invoke(gameObject);
            }
        }
    }
}
