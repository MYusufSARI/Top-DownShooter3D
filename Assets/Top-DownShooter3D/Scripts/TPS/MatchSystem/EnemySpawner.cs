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



        private void Awake()
        {
            _mainCamera = Camera.main;

            _plane = new Plane(Vector3.up, Vector3.zero);
        }


        private void Start()
        {
            StartCoroutine(CreateEnemy());
        }


        private IEnumerator CreateEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                var viewportPoint = new Vector3(-0.2f, Random.value);
                var ray = _mainCamera.ViewportPointToRay(viewportPoint);

                if (_plane.Raycast(ray, out float enter))
                {
                    var worldPos = ray.GetPoint(enter);
                    var inst = GameObject.CreatePrimitive(PrimitiveType.Capsule);

                    inst.transform.position = worldPos;
                }
            }
        }
    }
}