using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.WeaponSystem.FX
{
    public class WeaponParticleFX : WeaponFX
    {
        [Header("Elements")]
        [SerializeField] protected ParticleSystem[] _particleSystems;



        protected override void OnShot()
        {
            foreach (var particle in _particleSystems)
            {
                particle.Play();
            }    
        }
    }
}
