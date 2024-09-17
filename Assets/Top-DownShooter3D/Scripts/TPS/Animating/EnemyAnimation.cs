using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Animating
{
    public class EnemyAnimation : MonoBehaviour
    {
        [Header("Elements")]
        [SerializeField] private Animator _animator;

        [Header("Readonly")]
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int IsDead = Animator.StringToHash("Death");


        public void PlayAttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }


        public void PlayDeathAnimation()
        {
            _animator.SetBool(IsDead, true);
        }
    }
}
