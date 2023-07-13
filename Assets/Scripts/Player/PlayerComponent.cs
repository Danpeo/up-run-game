using System;
using Score;
using UnityEngine;

namespace Player
{
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField] private float _gravityScaleMultiplier = 0.05f;
        [SerializeField] private float _jumpSpeedMultiplier = 6;
        [SerializeField] private int _updatePlayerCharacteristicsFrequency = 10;
        private PlayerLocomotionComponent _locomotionComponent;
        public Rigidbody2D RigidBody { get; private set; }
        private SpriteRenderer _spriteRenderer;
        public float CurrentPositionY { get; private set; }

        public Animator Animator { get; private set; }
        private ScoreCounter _scoreCounter;

        private void Awake()
        {
            _scoreCounter = FindObjectOfType<ScoreCounter>();
            RigidBody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _locomotionComponent = GetComponent<PlayerLocomotionComponent>();
            Animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            if (_scoreCounter != null)
                _scoreCounter.OnScoreCnanged += UpdatePlayerCharacteristics;
        }

        private void UpdatePlayerCharacteristics(int score)
        {
            if (score % _updatePlayerCharacteristicsFrequency == 0)
            {
                RigidBody.gravityScale += _gravityScaleMultiplier;
                PlayerLocomotionComponent.Instance.JumpSpeed = RigidBody.gravityScale * _jumpSpeedMultiplier;
            }
        }

        private void OnDestroy()
        {
            if (_scoreCounter != null)
                _scoreCounter.OnScoreCnanged -= UpdatePlayerCharacteristics;
        }

        private void FixedUpdate()
        {
            CurrentPositionY = transform.position.y;
            _locomotionComponent.HandleLocomotion();
            UpdateSpriteDirection();
        }

        private void UpdateSpriteDirection()
        {
            if (_locomotionComponent.MovementDirection.x > 0)
            {
                _spriteRenderer.flipX = true;

            }
            else if (_locomotionComponent.MovementDirection.x < 0)
            {
                _spriteRenderer.flipX = false;
            }
        }
    }
}
