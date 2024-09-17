using System.Collections;
using System.Collections.Generic;
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



        private void Awake()
        {
            _itemDropper = GetComponent<ItemDropper>();
            _enemyAttacker = GetComponent<EnemyAttacker>();
            _enemyAnimation = GetComponent<EnemyAnimation>();
        }


        public void ApplyDamage(float damage, GameObject causer = null)
        {
            _health -= damage;

            if (_health <= 0)
            {
                gameObject.SetActive(false);

                if (_itemDropper)
                {
                    _itemDropper.OnDied();
                }
            }
        }
    }
}