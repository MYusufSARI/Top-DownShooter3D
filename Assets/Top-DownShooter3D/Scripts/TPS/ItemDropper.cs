using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS
{
    public class ItemDropper : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _xp;
        [SerializeField , Range(0,1)] private float _xpDropChange;

        [Header("Data")]
        [SerializeField] private XPCollectable _xpCollectablePrefab;



        public void OnDied()
        {
            if (_xpCollectablePrefab && Random.value > _xpDropChange)
            {
                var inst = Instantiate(_xpCollectablePrefab, transform.position, Quaternion.identity);

                inst.XP = _xp;
            }
        }
    }
}
