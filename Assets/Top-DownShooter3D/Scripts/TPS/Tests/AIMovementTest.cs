using System.Collections;
using System.Collections.Generic;
using TPS.MatchSystem;
using TPS.Movement;
using UnityEngine;

namespace TPS.Tests
{
    public class AIMovementTest : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private MatchInstance _matchInstance;

        private CharacterMovement _characterMovement;

        [Header("Settings")]
        [SerializeField] private float _acceptanceRadius;



        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
        }


        private void Update()
        {
            var distance = Vector3.Distance(transform.position, _matchInstance.Player.transform.position);

            if (distance > _acceptanceRadius)
            {
                var direction = (_matchInstance.Player.transform.position - transform.position).normalized;

                _characterMovement.MovementInput = new Vector2(direction.x, direction.z);
            }
        }
    }
}
