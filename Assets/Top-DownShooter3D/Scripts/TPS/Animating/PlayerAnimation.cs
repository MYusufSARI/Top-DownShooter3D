using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Animating
{
    public class PlayerAnimation : MonoBehaviour
    {
        [Header("Elements")]
        [SerializeField] private Animator _animator;

        public Vector3 Velocity { get; set; }

        [Header("Readonly")]
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");



        private void Update()
        {
            _animator.SetFloat(Horizontal, Velocity.x);
            _animator.SetFloat(Vertical, Velocity.z);
        }
    }
}
