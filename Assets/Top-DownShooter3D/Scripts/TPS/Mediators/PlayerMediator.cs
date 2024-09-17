using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TPS.Movement;
using TPS.Input;
using TPS.UI;
using TPS.BoosterSystem;

namespace TPS.Mediatiors
{
    public class PlayerMediator : MonoBehaviour, IDamageable
    {
        [SerializeField] private Attributes _attributes;
        public Attributes Attributes => _attributes;

        [Header("Data")]
        private CharacterMovement _characterMovement;
        private Shooter _shooter;
        private GameInput _gameInput;
        private Plane _plane;
        private XPCollectableAttractor _xpCollectableAttractor;
        private BoosterContainer _boosterContainer;



        [Header("Settings")]
        [SerializeField] private float _dodgePower;
        [SerializeField] private float _health;
        private float _xp;
        private int _level;

        public int Level => _level;

        public float MaxXP => (_level + 1) * 5;

        [Header("Elements")]
        private Camera _mainCamera;


        public event Action<int> OnLevelUp;


        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();

            _shooter = GetComponent<Shooter>();

            _xpCollectableAttractor = GetComponent<XPCollectableAttractor>();

            _boosterContainer = GetComponent<BoosterContainer>();

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


        private void OnAttractorXPCollected(float xp)
        {
            AddXP(xp);
        }


        private void OnDodgeRequested(InputAction.CallbackContext context)
        {
            _characterMovement.ExternalForces += _characterMovement.Velocity.normalized * _dodgePower;
        }


        private void Update()
        {
            HandleAttributes();
            HandleMovement();

            if (_gameInput.Player.Shoot.IsPressed())
            {
                _shooter.Shoot();
            }
        }


        private void HandleAttributes()
        {
            _characterMovement.MovementSpeed = Attributes.MovementSpeed;

            _shooter.AttackSpeedMultiplier = Attributes.AttackSpeed;
            _shooter.BaseDamage = Attributes.Damage;
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


        private void AddXP(float value)
        {
            _xp += value;

            if (_xp >= MaxXP)
            {
                LevelUp();
            }
        }


        private void LevelUp()
        {
            _level++;
            _xp = 0;

            if (PopupChannel.TryGetPopup<BoosterSelectionPopup>(out var popup))
            {
                popup.TargetBoosterContainer = _boosterContainer;

                popup.Open();
            }

            OnLevelUp?.Invoke(_level);
        }


        public void ApplyDamage(float damage, GameObject causer = null)
        {
            _health -= damage * (1 - Attributes.Defence);
        }
    }
}
