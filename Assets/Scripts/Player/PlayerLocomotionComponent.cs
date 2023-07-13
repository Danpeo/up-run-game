using System;
using Components;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerLocomotionComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        public float MoveSpeed
        {
            get => _moveSpeed;
            set => _moveSpeed = value;
        }
        [SerializeField] private float _jumpSpeed = 5f;
        public float JumpSpeed
        {
            get => _jumpSpeed;
            set => _jumpSpeed = value;
        }

        [SerializeField] private ColliderCheckComponent _groundCheck;
        [SerializeField] private UnityEvent<GameObject> _onJump;

        private PlayerComponent _player;
        private Vector2 _movementDirection;
        public Vector2 MovementDirection => _movementDirection;
        private float _xVelocity;
        private float _yVelocity;
        private bool _isJumping;
        private static readonly int Jump = Animator.StringToHash("Jump");
        
        public static PlayerLocomotionComponent Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
            
            _player = GetComponent<PlayerComponent>();

        }

        public void HandleLocomotion()
        {
            HandleGroundedMovement();
            HandleJumping();
            _player.RigidBody.velocity = new Vector2(_xVelocity, _yVelocity);
        }

        private void HandleGroundedMovement()
        {
            //GetMovementDirection();

            _xVelocity = _movementDirection.x * _moveSpeed;
        }

        private void HandleJumping()
        {
            _yVelocity = _player.RigidBody.velocity.y;

            if (_groundCheck.IsTouchingLayer)
            {
                _isJumping = false;
            }

            _isJumping = true;
            const float fallingValue = 0.001f;
            var isFalling = _player.RigidBody.velocity.y <= fallingValue;

            _yVelocity = isFalling ? CalculateJumpVelocity(_yVelocity) : _yVelocity;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            if (_groundCheck.IsTouchingLayer)
            {
                yVelocity = _jumpSpeed;
                _player.Animator.SetTrigger(Jump);
                _onJump?.Invoke(gameObject);
            }

            return yVelocity;
        }

        private void GetMovementDirection()
        {
            _movementDirection = PlayerInputReader.I.MovementDirection;
        }

        public void SetMovementDirection(Vector2 direction)
        {
            _movementDirection = direction;
        }
    }
}