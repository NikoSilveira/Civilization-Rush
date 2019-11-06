using UnityEngine.Audio;
using UnityEngine;

/*
 -Este script genera variables para control de audio (volume, pitch, loop)
 -Se elimina Monobehaviour y se cambia a Serializable para incorporar estas 
    variables en el inspector del AudioController
 */

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup mixerGroup;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
