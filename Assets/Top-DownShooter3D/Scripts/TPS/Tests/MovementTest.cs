using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TPS.Input;
using System;
using TPS.Movement;

namespace TPS.Tests
{
    public class MovementTest : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Vector2 _movementInput;
        [SerializeField] private Vector3 _externalForceValue;

        [Header("Elements")]
        [SerializeField] private CharacterMovement _characterMovement;

        [Header("Data")]
        private GameInput _gameInput;



        private void Awake()
        {
            _gameInput = new GameInput();
        }


        private void OnEnable()
        {
            _gameInput.Enable();

            _gameInput.Player.Dodge.performed += OnDodgeButtonPressed;
        }


        private void OnDisable()
        {
            _gameInput.Disable();

            _gameInput.Player.Dodge.performed -= OnDodgeButtonPressed;
        }


        private void OnDodgeButtonPressed(InputAction.CallbackContext context)
        {
            _characterMovement.ExternalForces += _externalForceValue;
        }


        private void Update()
        {
            var input = _gameInput.Player.Movement.ReadValue<Vector2>();
            _characterMovement.MovementInput = input;

            _characterMovement.Rotation += Time.deltaTime * 10f;
        }
    }
}
