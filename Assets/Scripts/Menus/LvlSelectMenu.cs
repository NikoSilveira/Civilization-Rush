using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

/*
    -Script de control del menú de selección de niveles
    -Se asigna este script al Onclick() del botón deseado
    junto con el ID del nivel
    -La carga de niveles se controla desde level loader
 */

public class LvlSelectMenu : MonoBehaviour
{
    //Variables que almacenan los paneles de la escena (asignar en inspector)
    public GameObject MainMenuPanel;
    public GameObject LevelPanel;
    public GameObject InfoPanel;

    //Array para almacenar los botones
    public Button[] levelButtons;
    public Button[] infoButtons;


    void Start()
    {
        //Recibir el nivel alcanzado de archivo local
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        //Desactivar botones, habilitar para niveles disponibles
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
                infoButtons[i].interactable = false;
            }
        }
    }


    //Volver al menú principal
    public void Back()
    {
        LevelPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    //Menú de info
    public void Info()
    {
        LevelPanel.SetActive(false);
        InfoPanel.SetActive(true);
    }

    //Volver al menú de niveles
    public void Back2()
    {
        InfoPanel.SetActive(false);
        LevelPanel.SetActive(true);
    }

    //Efecto de sonido al pisar boton
    public void SoundEffect()
    {
        FindObjectOfType<AudioManager>().Play("Press");
    }

}
