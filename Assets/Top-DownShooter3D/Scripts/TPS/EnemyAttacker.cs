using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS
{
    public class EnemyAttacker : MonoBehaviour, IDamageExecutor
    {
        [Header("Settings")]
        [SerializeField] private float _damage;
        [SerializeField] private float _attackRate;
        [SerializeField] private float _range;

        private float _lastAttack;

        [Header("Data")]
        private IDamageable _currentTarget;


        public float Range => _range;
        public bool CanAttack => Time.time > _lastAttack + _attackRate;
        public bool IsCurrentlyAttacking { get; private set; }

        public event Action<IDamageable> OnAttacked;



        public void Attack(IDamageable target)
        {
            if (!CanAttack)
                return;

            _lastAttack = Time.time;

            OnAttacked?.Invoke(target);

            _currentTarget = target;
            IsCurrentlyAttacking = true;
        }


        public void ExecuteDamage()
        {
            if (_currentTarget == null)
                return;

            if (_currentTarget is MonoBehaviour mb)
            {
                if (Vector3.Distance(mb.transform.position, transform.position) < _range)
                {
                    _currentTarget.ApplyDamage(_damage);
                }
            }

            else
            {
                _currentTarget.ApplyDamage(_damage);
            }

            IsCurrentlyAttacking = false;
        }
    }
}
