﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Variables que almacenan los paneles de la escena (asignar en inspector)
    public GameObject MainMenuPanel;
    public GameObject LevelPanel;
    public GameObject SettingsPanel;

    //Cada función corresponde a un botón, asignar en el inspector
    public void PlayGame()
    {
        //Menú selección de nivel
        MainMenuPanel.SetActive(false);
        LevelPanel.SetActive(true);
    }

    public void Settings()
    {
        //Menú de opciones
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        //Cerrar la app (teléfono)
        Application.Quit();
    }

    public void SoundEffect()
    {
        FindObjectOfType<AudioManager>().Play("Press");
    }

}
