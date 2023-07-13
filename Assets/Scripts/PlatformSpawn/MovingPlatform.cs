using UnityEngine;
using Utils;

namespace PlatformSpawn
{
    public class MovingPlatform : Platform
    {
        [SerializeField] private float _movingSpeed = 5f;

        private Vector3 _startPosition;
        private float _leftBoundary;
        private float _rightBoundary;
        private bool _movingRight;

        private void Start()
        {
            _movingRight = RandomExtension.RandomBool();
            
            _startPosition = transform.position;
            float cameraWidth = Camera.main.aspect * Camera.main.orthographicSize;
            _leftBoundary = _startPosition.x - cameraWidth;
            _rightBoundary = _startPosition.x + cameraWidth;
        }

        protected override void Update()
        {
            base.Update();
            Move();

        }

        private void Move()
        {
            var newPosition = transform.position;
            var movement = _movingSpeed * Time.deltaTime;
            if (_movingRight)
            {
                newPosition.x += movement;
            }
            else
            {
                newPosition.x -= movement;
            }

            transform.position = newPosition;
        }
    }
}
