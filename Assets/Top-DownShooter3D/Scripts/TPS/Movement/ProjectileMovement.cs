using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Movement
{
    public class ProjectileMovement : MonoBehaviour
    {
        [Header(" Settings ")]
        [SerializeField] private float _speed;
        [SerializeField] private float _pushPower;
        [SerializeField] private bool _shouldDestroyOnCollision;
        [SerializeField] private bool _shouldDisableOnCollision;
        [SerializeField] private bool _shouldBounce;
        [SerializeField] private Vector3 _movementPlane = Vector3.one;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public bool ShouldDestroyOnCollision
        {
            get => _shouldDestroyOnCollision;
            set => _shouldDestroyOnCollision = value;
        }

        public bool ShouldDisableOnCollision
        {
            get => _shouldDisableOnCollision;
            set => _shouldDisableOnCollision = value;
        }

        public bool ShouldBounce
        {
            get => _shouldBounce;
            set => _shouldBounce = value;
        }


        public event Action<RaycastHit> OnImpacted;



        private void Update()
        {
            var direction = transform.forward;

            direction.x *= _movementPlane.x;
            direction.y *= _movementPlane.y;
            direction.z *= _movementPlane.z;

            direction.Normalize();

            var distance = _speed * Time.deltaTime;
            var targetPosition = transform.position + direction * distance;

            if (Physics.Raycast(transform.position, direction, out var hit, distance))
            {
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(-hit.normal * _speed * _pushPower, hit.point, ForceMode.Impulse);
                }

                if (ShouldDestroyOnCollision)
                {
                    Destroy(gameObject);
                }

                if (ShouldDisableOnCollision)
                {
                    enabled = false;
                }

                targetPosition = hit.point;

                OnImpacted?.Invoke(hit);

                if (ShouldBounce)
                {
                    var reflectedDirection = Vector3.Reflect(direction, hit.normal);
                    transform.forward = reflectedDirection;
                }
            }

            Debug.DrawLine(transform.position, targetPosition, Color.red);

            transform.position = targetPosition;

            Debug.DrawRay(transform.position, direction * distance, Color.blue);
        }
    }
}
