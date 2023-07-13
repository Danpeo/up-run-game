using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputReader : MonoBehaviour
    {
        private PlayerLocomotionComponent _plc;
        
        public Vector2 MovementDirection { get; private set; }

        private PlayerControls _playerControls;
        
        //singleton
        private static PlayerInputReader _instance;
        public static PlayerInputReader I => _instance;
        private void Awake()
        {
            InitializeSingleton();

            _plc = GetComponent<PlayerLocomotionComponent>();
        }

        private void InitializeSingleton()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(gameObject);
        }

        private void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new PlayerControls();
                //OnMove(_playerControls.PlayerMovement.Movement.ReadValue<Vector2>());
            }
            
            _playerControls.Enable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            //_playerControls.PlayerMovement.Movement.performed += i => MovementDirection = i.ReadValue<Vector2>();
            var movementDirection = context.ReadValue<Vector2>();
            _plc.SetMovementDirection(movementDirection);
            
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (enabled)
            {
                if (hasFocus)
                {
                    _playerControls.Enable();
                }
                else
                {
                    _playerControls.Disable();
                }
            }
        }
    }
}
