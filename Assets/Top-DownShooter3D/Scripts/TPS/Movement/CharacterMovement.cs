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


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }
    }
}
