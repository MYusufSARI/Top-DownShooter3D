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
        [SerializeField] private MatchInstance? _matchInstance;



        public override void Begin(AIController aiController)
        {
            if (aiController.TryGetState<BasicAIState>(out var state))
            {
                state.CharacterMovement = aiController.GetComponent<CharacterMovement>();
                state.Attacker = aiController.GetComponent<EnemyAttacker>();
                state.PlayerDamageable = _matchInstance.Player.GetComponent<IDamageable>();
            }
        }


        protected override void Execute(AIController aiController)
        {
            if (!aiController.TryGetState<BasicAIState>(out var state))
            {
                return;
            }
            
            var player = _matchInstance.Player;
            var movement = state.CharacterMovement;
            var dist = Vector3.Distance(player.transform.position, aiController.transform.position);

            if (dist< _acceptanceRadius || !state.Attacker.IsCurrentlyAttacking)
            {
                var dir = (player.transform.position - aiController.transform.position).normalized;

                movement.MovementInput = new Vector2(dir.x, dir.z);

                player.transform.rotation = Quaternion.LookRotation(dir);

            }

            if (dist<state.Attacker.Range)
            {
                state.Attacker.Attack(state.PlayerDamageable);
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
