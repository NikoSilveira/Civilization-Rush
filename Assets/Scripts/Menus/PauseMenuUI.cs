using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
    -Este script crea un objeto pauseMenuUI para
    poder controlar el status del menu de pausa
    -SetActive permite activar o desactivar el Menú
    cuando se abre o se cierra
*/


[RequireComponent(typeof(Button))]
public class PauseMenuUI : MonoBehaviour
{

    public GameObject pauseMenuUI;

    //Bool de control para la pausa
    public static bool GameIsPaused = false;

    //Variables para control del sprite del boton mute
    public Sprite unmuted;
    public Sprite muted;

    public Button muteButton;


    void Start()
    {
        
    }

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
        
        //SFX
        FindObjectOfType<AudioManager>().Play("Pause");
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;

        //SFX
        FindObjectOfType<AudioManager>().Play("Pause");
    }

    public void ToggleAudio()
    {
        //Activar o descativar master audio

        if(AudioListener.volume == 0f)
        {
            //unmute
            AudioListener.volume = 1f;
            muteButton.image.overrideSprite = unmuted;
        }
        else if(AudioListener.volume == 1f)
        {
            //mute
            AudioListener.volume = 0f;
            muteButton.image.overrideSprite = muted;
        }
    }

    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;

        //SFX
        FindObjectOfType<AudioManager>().Play("Pause");

        //Recargar nivel
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;

        //SFX
        FindObjectOfType<AudioManager>().Play("Pause");

        //Volver a menú principal
        SceneManager.LoadScene(0);
    }
    
}
