using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.BoosterSystem
{
    public class BoosterList : ScriptableObject
    {
        [Header("Elements")]
        private List<Booster> _boosters = new List<Booster>();

        public List<Booster> Booster => _boosters;
    }
}
