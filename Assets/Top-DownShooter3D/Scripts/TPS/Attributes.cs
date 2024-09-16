using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS
{
    [System.Serializable]
    public class Attributes
    {
        [SerializeField] private float _damage = 0;
        [SerializeField] private float _movementSpeed = 5;
        [SerializeField] private float _attackSpeed = 1;
        [SerializeField] private float _defence = 0;

        public float Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public float MovementSpeed
        {
            get => _movementSpeed;
            set => _movementSpeed = value;
        }

        public float AttackSpeed
        {
            get => _attackSpeed;
            set => _attackSpeed = value;
        }

        public float Defence
        {
            get => _defence;
            set => _defence = Mathf.Clamp(value, 0, 0.95f);
        }
    }
}
