using System;
using System.Collections;
using System.Linq;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PlatformSpawn
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerComponent _player;
        [SerializeField] private SpawnData[] _platformData;
        [SerializeField] private float _spawnRate = 1f;
        [SerializeField] private float _spawnDistance = 10f;

        [SerializeField] private bool _spawn = true;
        private float _addToYPosValue = 0f;
        
        private float _minXSpawnPosition;
        private float _maxXSpawnPosition;

        [SerializeField] private float _minYSpawnPosition;
        [SerializeField] private float _maxYSpawnPosition;
        
        private float _platformWidth;
        private float _lastSpawnPositionY;
        private float _distanceToLastPlatform;

        private void Awake()
        {
            StartCoroutine(SpawnPlatforms());
        }

        private void Start()
        {
            CalculateMinAndMaxSpawnPositionX();
        }

        private void Update()
        {
            if (_spawn && _player != null)
                _distanceToLastPlatform = _player.transform.position.y - _lastSpawnPositionY;
        }

        private void CalculateMinAndMaxSpawnPositionX()
        {
            var cameraHeight = 2f * Camera.main.orthographicSize;
            var cameraWidth = cameraHeight * Camera.main.aspect;

            _platformWidth = FindMaxPlatformWidth();

            _minXSpawnPosition = -cameraWidth / 2f + _platformWidth / 2f;
            _maxXSpawnPosition = cameraWidth / 2f - _platformWidth / 2f;
        }


        public GameObject SpawnWithCalculatedProbability()
        {
            float total = _platformData.Sum(platformData => platformData.Probability);
            var sortedSpawnPrfabs = _platformData.OrderBy(platformData => platformData.Probability);

            float random = Random.value * total;
            float current = 0f;

            GameObject objectToSpawn = null;
            
            foreach (var spawnPrfab in sortedSpawnPrfabs)
            {
                current += spawnPrfab.Probability;
                if (current > random)
                {
                    objectToSpawn = spawnPrfab.Prefab;
                    break;
                }
            }

            return objectToSpawn;
        }
        
        private IEnumerator SpawnPlatforms()
        {
            if (_platformData.Length == 0 && _player == null)
            {
                Debug.LogWarning("No platforms available to spawn or no player.");
                _spawn = false;
                yield break;
            }

            while (_spawn)
            {
                if (_distanceToLastPlatform >= _spawnDistance)
                {
                    var spawnPlatform = Instantiate(SpawnWithCalculatedProbability());

                    var xPosition = Random.Range(_minXSpawnPosition, _maxXSpawnPosition);
                    
                    spawnPlatform.transform.position = new Vector3(xPosition, transform.position.y + _addToYPosValue);
                    _lastSpawnPositionY = spawnPlatform.transform.position.y;

                    var yAddToPosValue = Random.Range(_minYSpawnPosition, _maxYSpawnPosition);
                    _addToYPosValue += yAddToPosValue;

                    yield return new WaitForSeconds(_spawnRate);
                }

                yield return null;
            }
        }

        private float FindMaxPlatformWidth()
        {
            float maxWidth = 0f;

            foreach (var platform in _platformData)
            {
                if (platform.Prefab.transform.localScale.x > maxWidth)
                {
                    maxWidth = platform.Prefab.transform.localScale.x;
                }
            }

            return maxWidth;
        }
        
        [Serializable]
        public class SpawnData
        {
            public GameObject Prefab;
            [Range(0, 100)] public float Probability = 0;
        }
    }
}