using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS
{
    public class XPCollectableAtrractor : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _tickInterval = 0.7f;
        [SerializeField] private float _attractionRadius = 5f;

        [Header("Elements")]
        [SerializeField] private LayerMask _layerMask;
        private Collider[] _collectablesInRange = new Collider[20];



        private void Start()
        {
            StartCoroutine(Execute());
        }


        private IEnumerator Execute()
        {
            while (true)
            {
                yield return new WaitForSeconds(_tickInterval);

                if (!enabled)
                    yield return null;

                var hitCount = Physics.OverlapSphereNonAlloc(transform.position, _attractionRadius, _collectablesInRange, _layerMask);


            }
        }
    }
}