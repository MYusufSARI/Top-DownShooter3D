using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TPS.Movement;
using TPS.Input;

namespace TPS.Mediatiors
{
    public class PlayerMediator : MonoBehaviour, IDamageable
    {
        [Header("Data")]
        private CharacterMovement _characterMovement;
        private Shooter _shooter;
        private GameInput _gameInput;
        private Plane _plane;
        private XPCollectableAttractor _xpCollectableAttractor;

        [Header("Settings")]
        [SerializeField] private float _dodgePower;
        [SerializeField] private float _health;
        private float _xp;

        [Header("Elements")]
        private Camera _mainCamera;



        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();

            _shooter = GetComponent<Shooter>();

            _xpCollectableAttractor = GetComponent<XPCollectableAttractor>();

            _gameInput = new GameInput();

            _plane = new Plane(Vector3.up, Vector3.zero);

            _mainCamera = Camera.main;
        }


        private void OnEnable()
        {
            _gameInput.Enable();
            _gameInput.Player.Dodge.performed += OnDodgeRequested;

            _xpCollectableAttractor.OnXPCollected += OnAttractorXPCollected;
        }


        private void OnDisable()
        {
            _gameInput.Disable();
            _gameInput.Player.Dodge.performed -= OnDodgeRequested;

            _xpCollectableAttractor.OnXPCollected -= OnAttractorXPCollected;
        }


        private void OnShootRequested(InputAction.CallbackContext context)
        {
            _shooter.Shoot();
        }


        private void OnDodgeRequested(InputAction.CallbackContext context)
        {
            _characterMovement.ExternalForces += _characterMovement.Velocity.normalized * _dodgePower;
        }


        private void Update()
        {
            HandleMovement();

            if (_gameInput.Player.Shoot.IsPressed())
            {
                _shooter.Shoot();
            }
        }


        private void HandleMovement()
        {
            var movementInput = _gameInput.Player.Movement.ReadValue<Vector2>();
            _characterMovement.MovementInput = movementInput;

            var ray = _mainCamera.ScreenPointToRay(_gameInput.Player.PointerPosition.ReadValue<Vector2>());
            var gamePadLookDir = _gameInput.Player.Look.ReadValue<Vector2>();

            if (gamePadLookDir.magnitude > 0.1f)
            {
                var angle = -Mathf.Atan2(gamePadLookDir.y, gamePadLookDir.x) * Mathf.Rad2Deg + 90;

                _characterMovement.Rotation = angle;
            }

            else
            {
                if (_plane.Raycast(ray, out float enter))
                {
                    var worldPosition = ray.GetPoint(enter);
                    var dir = (worldPosition - transform.position).normalized;
                    // Method 1 to calculate the angle from player position to world position for 3D games
                    // Quaternion.LookRotation(dir).eulerAngles.y;

                    // Method 2
                    var angle = -Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg + 90;

                    _characterMovement.Rotation = angle;
                }
            }
        }

        public void ApplyDamage(float damage, GameObject causer = null)
        {
            _health -= damage;
        }
    }
}
