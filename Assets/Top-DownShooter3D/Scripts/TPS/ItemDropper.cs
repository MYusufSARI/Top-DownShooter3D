using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS
{
    public class ItemDropper : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _xp;

        [Header("Data")]
        [SerializeField] private XPCollectable _xpCollectablePrefab;

        public void OnDied()
        {
            
        }
    }
}
