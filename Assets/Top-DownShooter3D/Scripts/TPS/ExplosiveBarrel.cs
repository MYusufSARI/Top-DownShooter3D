using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TPS.Movement;

namespace TPS
{
    [RequireComponent(typeof(CinemachineImpulseSource))]
    public class ExplosiveBarrel : MonoBehaviour, IDamageable
    {
        [Header("Settings")]
        [SerializeField] private float _health = 5;
        [SerializeField] private float _explosionRadius = 5f;
        [SerializeField] private float _explosionDamage = 5f;
        [SerializeField] private float _explosionForce = 50f;
        [SerializeField] private float _delayBeforeExplosion = 1f;
        [SerializeField] private float _cameraShakePower = 1f;
        [SerializeField] private AnimationCurve _explosionFalloff;

        [Header("Elements")]
        private CinemachineImpulseSource _impulseSource;

        private bool _isDead;



        private void Awake()
        {
            _impulseSource = GetComponent<CinemachineImpulseSource>();
        }


        public void ApplyDamage(float damage, GameObject cause = null)
        {
            if (_isDead) return;

            _health -= damage;

            if (_health <= 0f)
            {
                StartCoroutine(ExplodeDelayed());
                _isDead = true;
            }
        }


        private IEnumerator ExplodeDelayed()
        {
            yield return new WaitForSeconds(_delayBeforeExplosion);

            Explode();
        }


        private void Explode()
        {
            var hits = Physics.OverlapSphere(transform.position, _explosionRadius);

            foreach (var hit in hits)
            {
                if (hit.transform == transform) continue;

                var distance = Vector3.Distance(transform.position, hit.transform.position);
                var rate = distance / _explosionRadius;
                var falloff = _explosionFalloff.Evaluate(rate);

                if (hit.transform.TryGetComponent<IDamageable>(out var damageable))
                {
                    damageable.ApplyDamage(_explosionDamage * falloff);
                }

                if (hit.transform.TryGetComponent<CharacterMovement>(out var movement))
                {
                    movement.ExternalForces += (hit.transform.position - transform.position).normalized * _explosionForce * falloff;
                }

                if (hit.attachedRigidbody)
                {
                    hit.attachedRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 1, ForceMode.Impulse);
                }
            }

            _impulseSource.GenerateImpulseAt(transform.position, new Vector3(1, 1, 0) * _cameraShakePower);

            Destroy(gameObject);
        }
    }
}
