using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.WeaponSystem
{
    public class WeaponGraphics : MonoBehaviour
    {
        public event Action Shot;

        [Header("Settings")]
        [SerializeField] private Transform _shootTransform;

        public Transform ShootTransform => _shootTransform;



        public void OnShot()
        {
            Shot?.Invoke();
        }
    }
}
