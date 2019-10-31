using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
    -Script de control del menú de selección de niveles
    -Se asigna este script al Onclick() del botón deseado
    junto con el ID del nivel
 */

public class LvlSelectMenu : MonoBehaviour
{
    //Variables que almacenan los paneles de la escena (asignar en inspector)
    public GameObject MainMenuPanel;
    public GameObject LevelPanel;

    //Array para almacenar los botones
    public Button[] levelButtons;


    void Start()
    {
        //Recibir el nivel alcanzado de un archivo local
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        //Desactivar todos los botones al empezar
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }


    //Entrar a un nivel
    public void SelectLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }

    //Volver al menú principal
    public void Back()
    {
        LevelPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    //Efecto de sonido al pisar boton
    public void SoundEffect()
    {
        FindObjectOfType<AudioManager>().Play("Switch");
    }

    //Resetear los niveles desbloqueados
    public void resetProgress()
    {
        PlayerPrefs.SetInt("levelReached", 1);
        SceneManager.LoadScene(0);
    }
}
