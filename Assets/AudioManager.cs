using UnityEngine.Audio;
using UnityEngine;
using JetBrains.Annotations;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public Sounds[] sound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        foreach (var s in sound)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;    

        }

        
    }
    public void play(string name)
    {
        Sounds s = Array.Find(sound, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        s.audioSource.Play();
    }
}
