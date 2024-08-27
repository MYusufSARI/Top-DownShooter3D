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
        public Vector3 ExternalForces { get; set; }



        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }


        private void Update()
        {
            var movement = new Vector3(MovementInput.x, 0, MovementInput.y);

            _characterController.SimpleMove(movement + ExternalForces);

            ExternalForces = Vector3.Lerp(ExternalForces, Vector3.zero, 9 * Time.deltaTime);
        }
    }
}
