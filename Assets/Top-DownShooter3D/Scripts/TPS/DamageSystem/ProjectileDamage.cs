using System;
using TPS.Movement;
using UnityEngine;

namespace TPS
{
    public class ProjectileDamage : MonoBehaviour
    {
        [Header("Elements")]
        private ProjectileMovement _projectileMovement;

        [Header("Settings")]
        [SerializeField] private float _damage = 1;

        public float Damage
        {
            get => _damage;
            set
            {
                _damage = value;
            }
        }



        private void Awake()
        {
            _projectileMovement = GetComponent<ProjectileMovement>();
        }


        private void OnEnable()
        {
            _projectileMovement.Impacted += OnImpacted;
        }


        private void OnDisable()
        {
            _projectileMovement.Impacted -= OnImpacted;
        }


        private void OnImpacted(RaycastHit hit)
        {
            if (hit.transform.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.ApplyDamage(_damage, gameObject);
            }
        }
    }
}
