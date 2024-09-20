using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.WeaponSystem.FX
{
    public class WeaponSFX : WeaponFX
    {
        [Header("Elements")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;


        protected override void OnShot()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
