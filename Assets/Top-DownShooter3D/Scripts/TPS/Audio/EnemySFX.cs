using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Audio
{
    public class EnemySFX : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private SoundCue _damageCue;
        [SerializeField] private SoundCue _attackCue;

        [Header("Elements")]
        [SerializeField] private AudioSource _audioSource;



        public void PlayDamagedSFX()
        {
            _damageCue.PlayOneShot(_audioSource);
        }


        public void PlayAttackSFX()
        {
            _attackCue.PlayOneShot(_audioSource);
        }
    }
}
