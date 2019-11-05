using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;

    void Awake()
    {

        //Singleton (solo existe un audio manager en cualquier momento)
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Obtener valores de volumen, pitch y loop asignados en el inspector
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Theme");
    }


    //Play soundtrack - recibe nombre del audio file como parametro
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        //Si hay error con asignación de track, finalizar función
        if (s == null) 
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
    }

    //Stop soundtrack - recibe nombre del audio file a detener como parametro
    public void Stop(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

}
