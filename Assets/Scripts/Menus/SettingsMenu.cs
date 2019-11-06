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


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("musicVol", volume);
    }


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
