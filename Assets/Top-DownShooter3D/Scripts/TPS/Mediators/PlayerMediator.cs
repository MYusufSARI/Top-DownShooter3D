using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TPS.Movement;
using TPS.Input;

namespace TPS.Mediatiors
{
    public class PlayerMediator : MonoBehaviour
    {
        [Header(" Data ")]
        private CharacterMovement _characterMovement;
        private GameInput _gameInput;
        private Plane _plane;

        [Header(" Settings ")]
        [SerializeField] private float _dodgePower;

        [Header(" Elements ")]
        private Camera _mainCamera;



        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();

            _gameInput = new GameInput();

            _plane = new Plane(Vector3.up, Vector3.zero);

            _mainCamera = Camera.main;
        }


        private void OnEnable()
        {
            _gameInput.Enable();

            _gameInput.Player.Dodge.performed += OnDodgeRequested;
        }


        private void OnDisable()
        {
            _gameInput.Disable();

            _gameInput.Player.Dodge.performed -= OnDodgeRequested;
        }


        private void OnDodgeRequested(InputAction.CallbackContext context)
        {
            _characterMovement.ExternalForces += _characterMovement.Velocity.normalized * _dodgePower;
        }


        private void Update()
        {
            var movementInput = _gameInput.Player.Movement.ReadValue<Vector2>();

            _characterMovement.MovementInput = movementInput;

            var ray = _mainCamera.ScreenPointToRay();
        }
    }
}
