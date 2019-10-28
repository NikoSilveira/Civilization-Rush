using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {

        //Singleton manual
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

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

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        if (s == null) //Validación - si hay error con asignación de track, que no trate de hacer play
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        /*if (PauseMenuUI.GameIsPaused) //Bajar volumen durante pausa
        {
            s.source.pitch = .5f;
            s.source.volume = .2f;
        }*/

        s.source.Play();
    }
}
