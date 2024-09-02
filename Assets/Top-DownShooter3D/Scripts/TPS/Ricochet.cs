using System;
using System.Collections;
using System.Collections.Generic;
using TPS.Movement;
using UnityEngine;

namespace TPS
{
    public class Ricochet : MonoBehaviour
    {
        [Header("Data")]
        private ProjectileMovement _projectileMovement;

        [Header("Settings")]
        [SerializeField] private float _radius;
        [SerializeField] private float _ricochetCount = 5f;
        [SerializeField] private bool _removeOnComplete;



        private void Awake()
        {
            _projectileMovement = GetComponent<ProjectileMovement>();
        }


        private void OnEnable()
        {
            _projectileMovement.OnImpacted += ProjectileMovement_OnImpacted;
        }


        private void OnDisable()
        {
            _projectileMovement.OnImpacted -= ProjectileMovement_OnImpacted;
        }


        private void ProjectileMovement_OnImpacted(RaycastHit raycastHit)
        {
            if(_ricochetCount <= 0)
            {
                if(_removeOnComplete)
                {
                    Destroy(this);
                }

                return;
            }

            var hits = Physics.OverlapSphere(raycastHit.point, _radius);

            foreach (var hit in hits)
            {
                if (hit.transform != raycastHit.transform) continue;

                if (hit.transform.TryGetComponent<IDamageable>(out var _))
                {
                    var dir = (hit.transform.position - transform.position).normalized;

                    transform.forward = dir;

                    _ricochetCount--;

                    return;
                }
            }
        }
    }
}