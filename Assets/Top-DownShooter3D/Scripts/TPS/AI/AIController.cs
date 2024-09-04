using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.AI
{
    public class AIController : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private AIBehaviour _aiBehaviour;

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
    }
}
