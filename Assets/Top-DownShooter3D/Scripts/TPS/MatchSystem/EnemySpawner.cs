using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace TPS.MatchSystem
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header(" Elements ")]
        private Camera _mainCamera;



        private void Awake()
        {
            _mainCamera = Camera.main;
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

                var viewportPoint = new Vector3(-0.1f, 0, Mathf.Abs(_mainCamera.transform.position.z));

                var worldPosition = _mainCamera.ViewportToWorldPoint(viewportPoint);
            }
        }
    }
}