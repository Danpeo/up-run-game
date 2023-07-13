using Player;
using UnityEngine;

namespace PlatformSpawn
{
    public abstract class Platform : MonoBehaviour
    { 
        private PlayerComponent _player;
        [SerializeField] private float _destroyDistanceFromPlayer = 15f;
        private float _playerDestroyPositionY;
        protected virtual void Awake()
        {
            _player = FindObjectOfType<PlayerComponent>();
        }

        protected virtual void Update()
        {
            if (_player == null)
                return;
            
            _playerDestroyPositionY = _player.transform.position.y - _destroyDistanceFromPlayer;
            
            if (transform.position.y < _playerDestroyPositionY)
            {
                Destroy(gameObject);
            }
        }
    }
}