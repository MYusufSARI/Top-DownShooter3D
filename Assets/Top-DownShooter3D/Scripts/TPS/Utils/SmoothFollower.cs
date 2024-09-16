using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Utils
{
    public class SmoothFollower : MonoBehaviour
    {
        public Transform Target { get; set; }

        [Header("Settings")]
        private const float FOLLOW_SPEED = 5;
        private const float ACCEPTANCE_RADIUS = 1;

        private bool _reachedDestination;

        private Vector3 _smoothMovementVelocity;

        public event Action OnReachedDestination;



        private void Update()
        {
            if (Target)
            {
                transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref _smoothMovementVelocity , FOLLOW_SPEED * Time.deltaTime);

                if (Vector3.Distance(Target.position, transform.position) < ACCEPTANCE_RADIUS)
                {
                    if (!_reachedDestination)
                    {
                        OnReachedDestination?.Invoke();

                        _reachedDestination = true;
                    }
                }

                else
                {
                    _reachedDestination = false;
                }
            }
        }
    }
}
