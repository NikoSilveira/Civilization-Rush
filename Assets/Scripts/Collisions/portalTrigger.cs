using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
    -Este script crea un objeto que instancia a 
    PlayerPhone para obtener el score del jugador
 */

public class portalTrigger : MonoBehaviour
{

    private PlayerPhone player;
    private int PlayerScore;

    //Bool de control para finalizar nivel
    private bool levelCleared = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    void Update()
    {
        //Mantener el score local actualizado
        PlayerScore = player.Score;
    }


    //Colisión Player - Portal
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(PlayerScore >= 1500 && levelCleared == false)    //score mínimo
        {
            //Pasar de nivel + cambio de música
            levelCleared = true;
            FindObjectOfType<AudioManager>().Stop("Theme");
            FindObjectOfType<AudioManager>().Play("Victory");

            //Siguiente escena + delay (seg)
            Invoke("nextScene", 6);
        }
        else if(PlayerScore < 1500)                         //score mínimo
        {
            //Diálogo para indicar que faltan puntos
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

    }

    void nextScene()
    {
        SceneManager.LoadScene(0);
    }

}
