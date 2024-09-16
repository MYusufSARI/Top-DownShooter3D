using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.BoosterSystem
{
    [CreateAssetMenu(menuName = "BoosterList")]
    public class BoosterList : ScriptableObject
    {
        [Header("Elements")]
        private List<Booster> _boosters = new List<Booster>();

        public int Length => _boosters.Count;
        public Booster Get(int i) => _boosters[i];
    }
}
