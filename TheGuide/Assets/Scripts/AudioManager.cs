using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = false;
        }
    }

    public void PlaySound(string Soundname)
    {
        Sound sound = Array.Find(sounds, sound => sound.soundName == Soundname);
        sound.source.Play();
    }
}
