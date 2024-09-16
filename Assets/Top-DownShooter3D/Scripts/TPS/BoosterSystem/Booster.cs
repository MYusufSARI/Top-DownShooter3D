using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.BoosterSystem
{
    public abstract class Booster : ScriptableObject
    {
        [Header("Settings")]
        [SerializeField] private string _boosterName;
        [SerializeField] private string _description;

        public string BoosterName => _boosterName;
        public string Description => _description;



        public abstract void OnAdded(BoosterContainer container);
    }
}
