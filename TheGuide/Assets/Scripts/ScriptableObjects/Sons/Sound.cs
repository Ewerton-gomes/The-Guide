using UnityEngine.Audio;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Sound", menuName = "Sounds/Sound")]
public class Sound : ScriptableObject
{
    public AudioClip sound;
    public string soundName;
    [Range(0f,1f)] public float volume;
    [Range (.1f,3f)] public float pitch;
    [HideInInspector] public AudioSource source;

}
