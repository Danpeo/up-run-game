using Player;
using UnityEngine;

namespace Components.Destroying
{
    public class GameOverZone : MonoBehaviour
    {
        [SerializeField] private float _playerOffset = 15f;
        private PlayerComponent _player;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerComponent>();
        }

        private void Update()
        {
            if (_player == null)
                return;
            
            float playerPosY = _player.transform.position.y - _playerOffset;

            if (playerPosY > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, playerPosY, transform.position.z);
            }
        }
    }
}