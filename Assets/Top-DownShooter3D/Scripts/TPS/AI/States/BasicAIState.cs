using System.Collections;
using System.Collections.Generic;
using TPS.Movement;
using UnityEngine;

namespace TPS.AI.States
{
    public class BasicAIState : AIState
    {
        public CharacterMovement CharacterMovement { get; set; }

        public EnemyAttacker Attacker { get; internal set; }

        public IDamageable PlayerDamageable { get; internal set; }
    }
}
