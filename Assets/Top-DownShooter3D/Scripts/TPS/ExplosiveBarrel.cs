using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS
{
    public class ExplosiveBarrel : MonoBehaviour, IDamageable
    {
        [Header(" Settings ")]
        [SerializeField] private float _health = 5;



        public void ApplyDamage(float damage, GameObject cause = null)
        {
            _health -= damage;

            if (_health <= 0f)
            {
                Explode();
            }
        }


        private void Explode()
        {
            Destroy(gameObject);
        }
    }
}
