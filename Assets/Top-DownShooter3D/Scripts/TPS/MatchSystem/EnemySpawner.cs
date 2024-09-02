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

        [Header("Settings")]
        [SerializeField] private float _offset;

        [Header("Data")]
        [SerializeField] private MatchInstance _matchInstance;
        [SerializeField] private EnemySpawnData _enemySpawnData;



        private void Awake()
        {
            _mainCamera = Camera.main;

            _plane = new Plane(Vector3.up, Vector3.zero);
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
                yield return new WaitForSeconds(1);

                var viewportPoint = Vector3.zero;

                var offset = Vector3.zero;

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

                var ray = _mainCamera.ViewportPointToRay(viewportPoint);

                if (_plane.Raycast(ray, out float enter))
                {
                    var worldPos = ray.GetPoint(enter) + offset;
                    var inst = GameObject.CreatePrimitive(PrimitiveType.Capsule);

                    inst.transform.position = worldPos;
                }
            }
        }
    }
}