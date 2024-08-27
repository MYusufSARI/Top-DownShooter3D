using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : MonoBehaviour
    {
        [Header(" Elements ")]
        private CharacterController _characterController;

        public Vector2 MovementInput { get; set; }



        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }


        private void Update()
        {
            var movement = new Vector3(MovementInput.x, 0, MovementInput.y);

            _characterController.SimpleMove(movement);
        }
    }
}
