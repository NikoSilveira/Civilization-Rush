using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

/*
    -Script de control del menú de selección de niveles
    -Se asigna este script al Onclick() del botón deseado
    junto con el ID del nivel
    -Se controla la barra de carga desde este script
 */

public class LvlSelectMenu : MonoBehaviour
{
    //Variables que almacenan los paneles de la escena (asignar en inspector)
    public GameObject MainMenuPanel;
    public GameObject LevelPanel;

    //Array para almacenar los botones
    public Button[] levelButtons;
    public Button[] infoButtons;

    //Variables para loading bar
    public GameObject loadingScreen;
    public Slider slider;


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



    //----------------------------------
    //      FUNCIONES PARA BOTONES
    //----------------------------------

    //Funcion para selección de nivel
    public void SelectLevel(int levelID)
    {
        StartCoroutine(LoadAsync(levelID));
    }

    //Funcion asincrona para cargar nivel
    IEnumerator LoadAsync (int levelID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelID);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            //Obtener el progreso y pasarlo a la barra
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;
        }
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
