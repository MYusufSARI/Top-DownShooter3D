using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Animating
{
    public class PlayerAnimation : MonoBehaviour
    {
        [Header("Elements")]
        [SerializeField] private Animator _animator;

        [Header("Settings")]
        private Vector3 _appliedVelocity;
        private Vector3 _currentTransitionVelocity;

        public Vector3 Velocity { get; set; }

        [Header("Readonly")]
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Fire = Animator.StringToHash("Fire");



        private void Update()
        {
            var transformedVelocity = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * Velocity;

            _appliedVelocity = Vector3.SmoothDamp(_appliedVelocity, transformedVelocity, ref _currentTransitionVelocity,
                (transformedVelocity.magnitude < 0.01f ? 2 : 8) * Time.deltaTime);

            _animator.SetFloat(Horizontal, transformedVelocity.x);
            _animator.SetFloat(Vertical, transformedVelocity.z);
        }


        public void PlayFireAnimation()
        {
            _animator.SetTrigger(Fire);
        }

        public void SetAnimationController(RuntimeAnimatorController animationController)
        {
            _animator.runtimeAnimatorController = animationController;
        }
    }
}
