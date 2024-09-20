using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS.Audio
{
    [CreateAssetMenu(menuName ="Audio/Sound Cue")]
    public class SoundCue : ScriptableObject
    {
        [Header("Elements")]
        [SerializeField] private AudioClip[] _audioClips;



        public AudioClip Get()
        {
            return _audioClips[Random.Range(0, _audioClips.Length)];
        }


        public void PlayOneShot(AudioSource source)
        {
            source.PlayOneShot(Get());
        }
    }
}
