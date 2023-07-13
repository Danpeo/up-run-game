using System;
using Player;
using UnityEngine;

namespace Components.Destroying
{
    public class DestroyArea : MonoBehaviour
    {
        [SerializeField] private PlayerComponent _player;

        private void Update()
        {
            transform.position = _player.transform.position;
        }
    }
}
