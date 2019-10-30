using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //Cada función corresponde a un botón, asignar en el inspector
    
    public void PlayGame()
    {
        //Menú selección de nivel
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        //Cerrar la app (solo funciona en teléfono)
        Application.Quit();
    }

}
