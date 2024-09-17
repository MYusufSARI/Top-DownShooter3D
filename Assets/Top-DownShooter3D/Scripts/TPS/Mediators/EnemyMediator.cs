using System;
using System.Collections;
using System.Collections.Generic;
using TPS.AI;
using TPS.Animating;
using UnityEngine;

namespace TPS.Mediatiors
{
    public class EnemyMediator : MonoBehaviour, IDamageable
    {
        [Header("Settings")]
        [SerializeField] private float _health;

        [Header("Data")]
        private ItemDropper _itemDropper;
        private EnemyAttacker _enemyAttacker;
        private EnemyAnimation _enemyAnimation;
        private AIController _aiController;



        private void Awake()
        {
            _itemDropper = GetComponent<ItemDropper>();
            _enemyAttacker = GetComponent<EnemyAttacker>();
            _enemyAnimation = GetComponent<EnemyAnimation>();
            _aiController = GetComponent<AIController>();
        }


        private void OnEnable()
        {
            _enemyAttacker.OnAttacked += EnemyAttacker_Attacked;
        }


        private void OnDisable()
        {
            _enemyAttacker.OnAttacked -= EnemyAttacker_Attacked;
        }


        private void EnemyAttacker_Attacked(IDamageable obj)
        {
            _enemyAnimation.PlayAttackAnimation();
        }


        public void ApplyDamage(float damage, GameObject causer = null)
        {
            _health -= damage;

            if (_health <= 0)
            {
                _enemyAnimation.PlayDeathAnimation();

                _aiController.enabled = false;
                StartCoroutine(DisableDelayed());

                if (_itemDropper)
                {
                    _itemDropper.OnDied();
                }
            }
        }


        private IEnumerator DisableDelayed()
        {
            yield return new WaitForSeconds(2);

                gameObject.SetActive(false);
        }
    }
}