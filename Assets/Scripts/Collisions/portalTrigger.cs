﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
    -Este script crea un objeto que instancia a 
    PlayerPhone para obtener el score del jugador
    -Este script se comunica con el manejador
    de selección de nivel para control de niveles
    bloqueados y desbloqueados
 */

public class portalTrigger : MonoBehaviour
{

    private PlayerPhone player;
    private int PlayerScore;

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
            if (PlayerScore >= 1500 && levelCleared == false)    //score mínimo
            {
                //Pasar de nivel + cambio de música
                levelCleared = true;
                FindObjectOfType<AudioManager>().Stop("Theme");
                FindObjectOfType<AudioManager>().Play("Victory");

                //Desbloquear proximo nivel
                Unlock();

                //Siguiente escena + delay (seg)
                Invoke("nextScene", 6);
            }
            else if (PlayerScore < 1500)                         //score mínimo
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Desbloquear nivel (actualizar input en el inspector)
    public void Unlock()
    {
        PlayerPrefs.SetInt("levelReached", nextLevelToUnlock);
    }
}
