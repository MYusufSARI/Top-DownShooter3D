using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Mediatiors
{
    public class EnemyMediator : MonoBehaviour, IDamageable
    {
        [Header("Settings")]
        [SerializeField] private float _health;

        [Header("Data")]
        private ItemDropper _itemDropper;



        private void Awake()
        {
            _itemDropper = GetComponent<ItemDropper>();
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