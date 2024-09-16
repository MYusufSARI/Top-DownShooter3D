using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS
{
    public class XPCollectableAtrractor : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _tickInterval = 0.7f;



        private void Start()
        {
            StartCoroutine(Execute());
        }


        private IEnumerator Execute()
        {
            while (true)
            {
                yield return new WaitForSeconds(_tickInterval);


            }
        }
    }
}