using UnityEngine;
using UnityEngine.SceneManagement;

/*
    -Script de control del menú de selección de niveles
    -Se asigna el LevelSelector al boton correspondiente
    y se asigna este script al Onclick() junto con el ID del nivel
 */

public class LvlSelectMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject LevelPanel;


    //Pasar de nivel
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
}
