using System.Collections;
using System.Collections.Generic;
using TPS.Audio;
using UnityEngine;

namespace TPS.WeaponSystem.FX
{
    public class WeaponSFX : WeaponFX
    {
        [Header("Elements")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SoundCue _soundCue;


        protected override void OnShot()
        {
            _soundCue.PlayOneShot(_audioSource);
        }
    }
}
