using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS
{
    public class EnemyAttacker : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _damage;
        [SerializeField] private float _attackRate;


        public void Attack(IDamageable target)
        {

        }
    }
}
