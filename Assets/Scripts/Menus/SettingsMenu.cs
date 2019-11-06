using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    //Objetos tipo panel
    public GameObject MainMenuPanel;
    public GameObject SettingsMenuPanel;

    //Control de volumen
    public AudioMixer audioMixer;



    //---------------------
    //       SLIDERS
    //---------------------

    public void SetVolumeMaster(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("musicVol", volume);
    }

    public void SetVolumeSfx(float volume)
    {
        audioMixer.SetFloat("sfxVol", volume);
    }


    //------------------------
    //        BOTONES
    //------------------------

    //Resetear los niveles desbloqueados
    public void resetProgress()
    {
        PlayerPrefs.SetInt("levelReached", 1);
        SceneManager.LoadScene(0);
    }

    //Volver al menu principal
    public void Back()
    {
        SettingsMenuPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

}
