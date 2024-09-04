using System.Collections;
using System.Collections.Generic;
using TPS.AI.States;
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
            if (aIController.TryGetState<BasicAIState>(out var state))
            {
                state.CharacterMovement = aIController.GetComponent<CharacterMovement>();
            }
        }


        protected override void Execute(AIController aIController)
        {
            if (aIController.TryGetState<BasicAIState>(out var state))
            {
                return;
            }

            var player = _matchInstance.Player;

            var movement = state.CharacterMovement;

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


        public override AIState CreateState()
        {
            return new BasicAIState();
        }
    }
}
