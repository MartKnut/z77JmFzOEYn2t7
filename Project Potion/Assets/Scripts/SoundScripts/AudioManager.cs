using System;
using UnityEngine;

namespace SoundScripts
{
    public class AudioManager : MonoBehaviour
    {
    
        public static AudioManager Instance;
    
        public Sound[] sounds;

        private void Awake()
        {
        
            if (Instance == null) Instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }
        
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
            }
        }

    

        public void Play(string soundName)
        {
            Sound s = Array.Find(sounds, sound => sound.name == soundName);
            s.source.Play();
        }
    }
}
