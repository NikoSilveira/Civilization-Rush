using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
    -Este script crea un objeto que instancia a 
    PlayerPhone para obtener el score del jugador
    -Este script se comunica con el manejador
    de selección de nivel para control de niveles
    bloqueados y desbloqueados
    -SI SE NECESITA MODIFICAR SCORE PARA PASAR POR PORTAL
    HAY QUE CAMBIAR EN AMBAS CONDICIONES DE LA COLISION
 */

public class portalTrigger : MonoBehaviour
{
    
    private PlayerPhone player;
    public InOutController2 controller2;

    private int PlayerScore;

    //Control de score minimo
    public int minimumScore;
    private int sceneIndex;

    //Bool de control para finalizar nivel
    private bool levelCleared = false;

    //Variables para desbloqueo de siguiente nivel
    public string nextLevel = "Level2";
    public int nextLevelToUnlock = 2;

    //Bool de control de colisión con portal
    public bool validateCollision = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        //Mantener el score local actualizado
        PlayerScore = player.Score;
    }


    //Colisión Player - Portal
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerScore >= minimumScore && levelCleared == false)    //score mínimo
            {
                //Pasar de nivel + cambio de música
                levelCleared = true;
                FindObjectOfType<AudioManager>().Stop("Theme");
                FindObjectOfType<AudioManager>().Play("Victory");

                //Desbloquear proximo nivel y guardar nuevo record
                Unlock();
                SetRecord();

                //Display info de victoria
                controller2.ShowFinishInfo();

                //Siguiente escena + delay (seg)
                Invoke("nextScene", 4);
            }
            else if (minimumScore < 1500)                         //score mínimo
            {
                //SFX
                FindObjectOfType<AudioManager>().Play("Error");

                if (validateCollision)
                {
                    //Activar dialogo de alerta
                    validateCollision = false;
                    gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                }
                
            }
        }
    }

    void nextScene()
    {
        //Activar la función de transición del controlador de niveles
        FindObjectOfType<LevelChanger>().FadeToNextLevel();
    }

    //Desbloquear nivel (actualizar input en el inspector)
    public void Unlock()
    {
        PlayerPrefs.SetInt("levelReached", nextLevelToUnlock);
    }

    //Almacenar record en documento
    public void SetRecord()
    {
        if(PlayerPrefs.GetInt("ScoreRecord" + SceneManager.GetActiveScene().buildIndex, 0) < player.Score)
        {
            PlayerPrefs.SetInt("ScoreRecord"+SceneManager.GetActiveScene().buildIndex, player.Score);
        }
    }

}
