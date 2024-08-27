using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Movement.Test
{
    public class MovementTest : MonoBehaviour
    {
        [Header(" Settings ")]
        [SerializeField] private Vector2 _movementInput;

        [Header(" Elements ")]
        [SerializeField] private CharacterMovement _characterMovement;



        private void Update()
        {
            _characterMovement.MovementInput = _movementInput;
        }
    }
}
