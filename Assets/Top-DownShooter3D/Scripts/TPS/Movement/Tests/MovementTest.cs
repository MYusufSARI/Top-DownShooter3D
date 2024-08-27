using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TPS.Movement.Test
{
    public class MovementTest : MonoBehaviour
    {
        [Header(" Settings ")]
        [SerializeField] private Vector2 _movementInput;
        [SerializeField] private Vector3 _externalForceValue;

        [Header(" Elements ")]
        [SerializeField] private CharacterMovement _characterMovement;



        private void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                _characterMovement.ExternalForces += _externalForceValue;
            }

            _characterMovement.MovementInput = _movementInput;
        }
    }
}
