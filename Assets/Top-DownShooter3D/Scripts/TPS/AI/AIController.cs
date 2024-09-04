using System.Collections;
using System.Collections.Generic;
using TPS.AI.States;
using UnityEngine;

namespace TPS.AI
{
    public class AIController : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private AIBehaviour _aiBehaviour;

        private AIState _aiState;

        public AIBehaviour AIBehaviour
        {
            get => _aiBehaviour;
            set
            {
                if (_aiBehaviour)
                {
                    _aiBehaviour.End(this);
                }

                _aiBehaviour = value;

                if (_aiBehaviour)
                {
                    _aiState = _aiBehaviour.CreateState();

                    _aiBehaviour.Begin(this);
                }
            }
        }



        private void Awake()
        {
            if (_aiBehaviour)
            {
                _aiBehaviour.Begin(this);
            }
        }



        private void Update()
        {
            if (AIBehaviour)
            {
                AIBehaviour.OnUpdate(this);
            }
        }


        public bool TryGetState<T>(out T state) where T : AIState
        {
            if (_aiState is T casted)
            {
                state = casted;

                return true;
            }

            else
            {
                state = null;

                return false;
            }
        }
    }
}
