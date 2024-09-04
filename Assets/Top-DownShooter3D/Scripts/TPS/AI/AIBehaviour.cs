using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace TPS.AI
{
    public abstract class AIBehaviour : ScriptableObject
    {
        public abstract void Begin(AIController aIController);

        public  void OnUpdate(AIController aIController)
        {
            Profiler.BeginSample($"AI Behaviour({name}).Enxecute");

            Execute(aIController);

            Profiler.EndSample();
        }

        public abstract void End(AIController aIController);

        protected abstract void Execute(AIController aIController);
    }
}
