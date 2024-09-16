using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Utils
{
    public class TransformFollower : MonoBehaviour
    {
        [Header("Elements")]
        [SerializeField] private Transform _target;



        private void LateUpdate()
        {
            transform.position = _target.position;
        }
    }
}
