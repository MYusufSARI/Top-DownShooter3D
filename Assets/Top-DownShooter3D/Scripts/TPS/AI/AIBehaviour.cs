using System;
using System.Collections;
using System.Collections.Generic;
using TPS.AI.States;
using UnityEngine;
using UnityEngine.Profiling;

namespace TPS.AI
{
    public abstract class AIBehaviour : ScriptableObject
    {
        public abstract void Begin(AIController controller);

        public void OnUpdate(AIController controller)
        {
            Profiler.BeginSample($"AIBehaviour({name}).Execute");
            Execute(controller);
            Profiler.EndSample();
        }
        public abstract void End(AIController controller);
        protected abstract void Execute(AIController controller);

        public virtual AIState CreateState()
        {
            return new NullAIState();
        }
    }
}
