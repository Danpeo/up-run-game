using Unity.Mathematics;
using UnityEngine;

namespace PlatformSpawn
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;
        
        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var instance = Instantiate(_prefab, _target.position, quaternion.identity);
            instance.transform.localScale = _target.lossyScale;
            instance.SetActive(true);
        }
    }
}
