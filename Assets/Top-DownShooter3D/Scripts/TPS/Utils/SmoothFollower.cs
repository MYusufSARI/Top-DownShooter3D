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
        private const float FOLLOW_SPEED = 8;
        private const float ACCEPTANCE_RADIUS = 1;
        private bool _reachedDestination;

        public event Action OnReachedDestination;


        private void Update()
        {
            if (Target)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target.position, FOLLOW_SPEED * Time.deltaTime);

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
