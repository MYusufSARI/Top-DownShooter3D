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
                _aiBehaviour = value;
            }
        }



        private void Update()
        {
            if (AIBehaviour)
            {
                AIBehaviour.Update(this);
            }
        }
    }
}
