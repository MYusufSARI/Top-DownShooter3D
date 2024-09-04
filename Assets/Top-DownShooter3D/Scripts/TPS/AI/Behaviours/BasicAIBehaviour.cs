using System.Collections;
using System.Collections.Generic;
using TPS.MatchSystem;
using TPS.Movement;
using UnityEngine;

namespace TPS.AI.Behaviours
{
    [CreateAssetMenu(menuName = "AI/Basic AI Behaviour")]
    public class BasicAIBehaviour : AIBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _acceptanceRadius;

        [Header("Data")]
        [SerializeField] private MatchInstance _matchInstance;



        public override void Begin(AIController aIController)
        {

        }


        protected override void Execute(AIController aIController)
        {
            var player = _matchInstance.Player;

            var movement = aIController.GetComponent<CharacterMovement>();
            var dist = Vector3.Distance(player.transform.position, aIController.transform.position);

            if (dist < _acceptanceRadius)
            {
                movement.MovementInput = Vector3.zero;
            }

            else
            {
                var dir = (player.transform.position - aIController.transform.position).normalized;

                movement.MovementInput = new Vector2(dir.x, dir.z);
            }
        }


        public override void End(AIController aIController)
        {

        }
    }
}
