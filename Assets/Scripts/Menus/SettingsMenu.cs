using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/*
 * -Se utiliza playerprefs para almacenar valores de audio a largo plazo
 */

public class SettingsMenu : MonoBehaviour
{

    //Objetos tipo panel
    public GameObject MainMenuPanel;
    public GameObject SettingsMenuPanel;
    public GameObject ConfirmPanel;

    //Control de volumen
    public AudioMixer audioMixer;

    //Sliders
    public Slider musicSlider;
    public Slider sfxSlider;


    //Al abrir escena 0
    private void Start()
    {
        //Obtener los valores guardados de audio
        float initialMusic = PlayerPrefs.GetFloat("musicVol", 0.7f);
        float initialSfx = PlayerPrefs.GetFloat("sfxVol", 0.7f);

        //Inicializar los sliders donde quedaron por ultima vez
        musicSlider.SetValueWithoutNotify(initialMusic);
        sfxSlider.SetValueWithoutNotify(initialSfx);

        //Establecer el valor inicial del volumen
        audioMixer.SetFloat("musicVol", Mathf.Log10(initialMusic) * 20);
        audioMixer.SetFloat("sfxVol", Mathf.Log10(initialSfx) * 20);
    }



    //---------------------
    //       SLIDERS
    //---------------------


    /*
     *  -Se utiliza logaritmo base 10 para convertir el volumen de decibeles (exponencial) a un valor lineal
     *  -Cada slider tiene un rango de 0.0001 a 1
     *  -Los valores de audio se guardan constantemente en e documento local
     */

    public void SetVolumeMaster(float volume)   //Master vol
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void SetVolumeMusic(float volume)    //Music vol
    {
        audioMixer.SetFloat("musicVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVol", volume);
    }

    public void SetVolumeSfx(float volume)      //SFX vol
    {
        audioMixer.SetFloat("sfxVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVol", volume);
    }


    //------------------------
    //        BOTONES
    //------------------------

    public void DeleteProgress()
    {
        ConfirmPanel.SetActive(true);
        SettingsMenuPanel.SetActive(false);
    }

    //Volver al menu principal
    public void Back()
    {
        SettingsMenuPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Press");
    }

}
