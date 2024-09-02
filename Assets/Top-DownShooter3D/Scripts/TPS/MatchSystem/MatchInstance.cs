using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.MatchSystem
{
    [CreateAssetMenu(menuName = "MatchInstance")]
    public class MatchInstance : ScriptableObject
    {
        public float Time { get; set; }
    }
}
