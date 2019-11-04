using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    -Este script crea un objeto pauseMenuUI para
    poder controlar el status del menu de pausa
    -SetActive permite activar o desactivar el Menú
    cuando se abre o se cierra
*/

public class PauseMenuUI : MonoBehaviour
{

    //Bool de control para la pausa
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        //Control por teclado (ESC)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }


    //----------------------------------------
    //   MÉTODOS PARA LOS BOTONES DEL MENÚ
    //----------------------------------------


    //Agregar funcion por cada botón

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void Settings()
    {

    }

    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }
    
}
