using System;
using TPS.WeaponSystem;
using UnityEngine;

namespace TPS.WeaponSystem.FX
{
    public abstract class WeaponFX : MonoBehaviour
    {
        [Header("Data")]
        private WeaponGraphics _weaponGraphics;



        private void Awake()
        {
            _weaponGraphics = GetComponent<WeaponGraphics>();
        }


        private void OnEnable()
        {
            _weaponGraphics.Shot += OnShot;
        }


        private void OnDisable()
        {
            _weaponGraphics.Shot -= OnShot;
        }


        protected abstract void OnShot();
    }
}
