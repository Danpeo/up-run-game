using System;
using Player;
using UnityEngine;

namespace Components
{
    public class ScreenWrapComponent : MonoBehaviour
    {
        [SerializeField] private float _offset = 1f;
        private float _screenLeftX;
        private float _screenRightX;

        private void Start()
        {
            _screenLeftX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
            _screenRightX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        }

        private void Update()
        {
            Wrap();
        }

        private void Wrap()
        {
            var currentPosition = transform.position;

            if (currentPosition.x < _screenLeftX - _offset)
            {
                currentPosition.x = _screenRightX;
            }
            else if (currentPosition.x > _screenRightX + _offset)
            {
                currentPosition.x = _screenLeftX;
            }

            transform.position = currentPosition;
        }
       
    }
}
