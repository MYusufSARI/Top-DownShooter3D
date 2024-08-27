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

        [Header(" Settings ")]
        [SerializeField] private float _moveSpeed = 4f;

        public Vector2 MovementInput { get; set; }
        public Vector3 ExternalForces { get; set; }
        public float Rotation { get; set; }

        public Vector3 Velocity => _characterController.velocity;



        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }


        private void Update()
        {
            var movement = new Vector3(MovementInput.x, 0, MovementInput.y);

            transform.eulerAngles = new Vector3(0, Rotation);

            _characterController.SimpleMove(movement * _moveSpeed + ExternalForces);

            ExternalForces = Vector3.Lerp(ExternalForces, Vector3.zero, 9 * Time.deltaTime);
        }
    }
}
