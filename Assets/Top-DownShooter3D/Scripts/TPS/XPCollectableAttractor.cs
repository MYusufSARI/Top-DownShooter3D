using System;
using System.Collections;
using System.Collections.Generic;
using TPS.Utils;
using UnityEngine;

namespace TPS
{
    public class XPCollectableAttractor : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _tickInterval = 0.7f;
        [SerializeField] private float _attractionRadius = 5f;

        [Header("Elements")]
        [SerializeField] private LayerMask _layerMask;
        private Collider[] _collectablesInRange = new Collider[20];

        public event Action<float> OnXPCollected;


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

                for (int i = 0; i < hitCount; i++)
                {
                    var collider = _collectablesInRange[i];
                    collider.enabled= false;

                    var follower = collider.gameObject.AddComponent<SmoothFollower>();
                    follower.Target = transform;
                    follower.OnReachedDestination += () =>
                    {
                        var collectable = follower.GetComponent<XPCollectable>();

                        OnXPCollected?.Invoke(collectable.XP);

                        Destroy(follower.gameObject);
                    };
                }
            }
        }
    }
}