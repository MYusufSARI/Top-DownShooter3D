using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS
{
    public class EnemyAttacker : MonoBehaviour
    {
        public event Action<IDamageable> OnAttacked;

        [Header("Settings")]
        [SerializeField] private float _damage;
        [SerializeField] private float _attackRate;
        [SerializeField] private float _range;

        private float _lastAttack;

        public float Range => _range;
        public bool CanAttack => Time.time > _lastAttack + _attackRate;
        public bool IsCurrentlyAttacking { get; private set; }



        public void Attack(IDamageable target)
        {
            if (!CanAttack) return;

            _lastAttack = Time.time;

            OnAttacked?.Invoke(target);

            StartCoroutine(ApplyAttackDelayed(target));
        }


        private IEnumerator ApplyAttackDelayed(IDamageable target)
        {
            IsCurrentlyAttacking = true;

            yield return new WaitForSeconds(0.5f);

            IsCurrentlyAttacking = false;

            if (target is MonoBehaviour mb)
            {
                if (Vector3.Distance(mb.transform.position, transform.position) < _range)
                {
                    target.ApplyDamage(_damage);
                }

                else
                {
                    target.ApplyDamage(_damage);
                }
            }
        }
    }
}
