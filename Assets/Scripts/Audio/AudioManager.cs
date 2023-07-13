using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSound[] _audioSounds;
        private AudioSource _audioSource;
        private int _audioClipIndex;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayAudioSound(string soundName)
        {
            int audioClilpIndex = 0;
            for (int i = 0; i < _audioSounds.Length; i++)
            {
                if (soundName == _audioSounds[i].SoundName)
                    break;

                audioClilpIndex++;
            }
            
            _audioSource.PlayOneShot(_audioSounds[audioClilpIndex].Clip);
            _audioClipIndex = 0;
        }

        [Serializable]
        public struct AudioSound
        {
            public string SoundName;
            public AudioClip Clip;
        }
    }
}
