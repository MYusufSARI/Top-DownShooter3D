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
        [Header(" Elements ")]
        private Camera _mainCamera;
        private Plane _plane;

        [Header(" Settings ")]
        [SerializeField] private float _offset;



        private void Awake()
        {
            _mainCamera = Camera.main;

            _plane = new Plane(Vector3.up, Vector3.zero);
        }


        private void Start()
        {
            StartCoroutine(CreateEnemy());
        }


        private Vector3 GetSpawnOffsetViewportPosition(Vector3 viewport)
        {

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
                    viewportPoint = new Vector3(Mathf.Round(Random.value), Random.value);
                }

                else
                {
                    viewportPoint = new Vector3(Random.value, Mathf.Round(Random.value));
                }

                offset = GetSpawnOffsetViewportPosition(viewportPoint);

                var ray = _mainCamera.ViewportPointToRay(viewportPoint);

                if (_plane.Raycast(ray, out float enter))
                {
                    var worldPos = ray.GetPoint(enter) - offset;
                    var inst = GameObject.CreatePrimitive(PrimitiveType.Capsule);

                    inst.transform.position = worldPos;
                }
            }
        }
    }
}