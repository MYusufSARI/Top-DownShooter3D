using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS
{
    public class TransformFollower : MonoBehaviour
    {
        [Header(" Elements ")]
        [SerializeField] private Transform _target;



        private void Update()
        {
            transform.position = _target.position;
        }
    }
}
