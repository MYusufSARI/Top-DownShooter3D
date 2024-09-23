using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace TPS.MatchSystem
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Elements")]
        private Camera _mainCamera;
        private Plane _plane;

        private GameObject[] _pooledObjects;

        [Header("Settings")]
        [SerializeField] private float _offset;
        [SerializeField] private float _spawnRate = 0.5f;

        private int _currentSpawnedObjectIndex;

        [Header("Data")]
        [SerializeField] private MatchInstance _matchInstance;
        [SerializeField] private EnemySpawnData _enemySpawnData;



        private void Awake()
        {
            _mainCamera = Camera.main;

            _plane = new Plane(Vector3.up, Vector3.zero);

            CreatePoolObjects();
        }


        public void CreatePoolObjects()
        {
            int totalSpawnCount = 0;

            foreach (var entry in _enemySpawnData.Entries)
            {
                totalSpawnCount += entry.SpawnCount;
            }

            _pooledObjects = new GameObject[totalSpawnCount];

            int currentSpawnIndex = 0;

            foreach (var entry in _enemySpawnData.Entries)
            {
                for (int i = 0; i < entry.SpawnCount; i++)
                {
                    var objectToSpawn = entry.Prefabs[Random.Range(0, entry.Prefabs.Length)];

                    GameObject inst = Instantiate(objectToSpawn, Vector3.zero, Quaternion.identity);
                    inst.SetActive(false);

                    _pooledObjects[currentSpawnIndex] = inst;

                    currentSpawnIndex++;
                }
            }
        }


        private void Start()
        {
            StartCoroutine(CreateEnemy());
        }


        private Vector3 GetSpawnOffsetViewportPosition(Vector3 vector, float sign)
        {
            return vector * sign * _offset;
        }


        private IEnumerator CreateEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnRate);

                if (!_enemySpawnData.TryGetEntryByTime(_matchInstance.Time, out SpawnEntry entry)) continue;


                var spawnPerCall = ((float)entry.SpawnCount / entry.Duration) * _spawnRate;

                for (int i = 0; i < spawnPerCall; i++)
                {
                    var viewportPoint = GetViewportPoint(out var offset);

                    var ray = _mainCamera.ViewportPointToRay(viewportPoint);

                    if (_plane.Raycast(ray, out float enter))
                    {
                        var worldPos = ray.GetPoint(enter) + offset;
                        var inst = _pooledObjects[_currentSpawnedObjectIndex];

                        inst.transform.position = worldPos;
                        inst.SetActive(true);

                        _currentSpawnedObjectIndex++;
                    }
                }

            }
        }


        private Vector3 GetViewportPoint(out Vector3 offset)
        {
            var viewportPoint = Vector3.zero;

            offset = Vector3.zero;

            if (Random.value > 0.5f)
            {
                var dir = Mathf.Round(Random.value);
                viewportPoint = new Vector3(dir, Random.value);

                offset = GetSpawnOffsetViewportPosition(Vector3.right, dir < 0.001f ? -1f : 1f);
            }

            else
            {
                var dir = Mathf.Round(Random.value);
                viewportPoint = new Vector3(Random.value, dir);

                offset = GetSpawnOffsetViewportPosition(Vector3.forward, dir < 0.001f ? -1f : 1f);
            }

            return viewportPoint;
        }
    }
}