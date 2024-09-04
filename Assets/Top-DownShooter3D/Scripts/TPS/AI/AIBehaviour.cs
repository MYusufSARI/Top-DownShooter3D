using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.AI
{
    public abstract class AIBehaviour : ScriptableObject
    {
        public abstract void Begin(AIController aIController);

        public abstract void Update(AIController aIController);

        public abstract void End(AIController aIController);

    }
}
