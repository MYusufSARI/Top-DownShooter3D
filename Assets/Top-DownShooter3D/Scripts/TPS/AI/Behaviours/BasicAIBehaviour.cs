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


        public override void End(AIController aIController)
        {
            var player = _matchInstance.Player;

            var movement = aIController.GetComponent<CharacterMovement>();

            var dir = (player.transform.position - aIController.transform.position).normalized;

            movement.MovementInput = new Vector2(dir.x, dir.z);
        }


        public override void Update(AIController aIController)
        {

        }
    }
}
