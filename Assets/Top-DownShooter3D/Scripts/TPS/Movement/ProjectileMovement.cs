using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Movement
{
    public class ProjectileMovement : MonoBehaviour
    {
        public event Action<RaycastHit> OnImpacted;
        public event Action DestroyRequested;

        [Header("Settings")]
        [SerializeField] private float _speed;
        [SerializeField] private float _pushPower;
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _spawnTime;
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



        private void Awake()
        {
            ResetSpawnTime();  
        }


        public void ResetSpawnTime()
        {
            _spawnTime = Time.time;
        }


        private void Update()
        {
            if (_lifeTime>0 && Time.time - _spawnTime > _lifeTime)
            {
                DestroyRequested?.Invoke();

                return;
            }

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
                    DestroyRequested?.Invoke();
                }

                if (ShouldDisableOnCollision)
                {
                    enabled = false;
                }

                targetPosition = hit.point + transform.forward * 0.01f; ;

                if (ShouldBounce)
                {
                    var reflectedDirection = Vector3.Reflect(direction, hit.normal);
                    transform.forward = reflectedDirection;
                }

                OnImpacted?.Invoke(hit);
            }

            Debug.DrawLine(transform.position, targetPosition, Color.red);
            transform.position = targetPosition;
            Debug.DrawRay(transform.position, direction * distance, Color.blue);
        }
    }
}
