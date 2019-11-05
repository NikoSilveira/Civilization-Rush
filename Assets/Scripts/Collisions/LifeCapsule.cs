using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    -Este script crea un objeto de tipo PlayerPhone para interactuar
    con los atributos de vida del jugador al obtener la botella
 */

public class LifeCapsule : MonoBehaviour
{

    private PlayerPhone player;

    //Cantidad de vida a recuperar
    public int lifeObtained = 3;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }


    //Colisión Player - Poción de vida
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(player.myHealth + lifeObtained > 9)
            {
                //Recuperar solo lo que falta de vida si es menor a lo que da la botella
                player.myHealth += (9 - player.myHealth);
                Destroy(gameObject);
            }
            else if(player.myHealth + lifeObtained <= 9)
            {
                //Recuperar vida (valor completo de la botella)
                player.myHealth += lifeObtained;
                Destroy(gameObject);
            }

            //SFX
            FindObjectOfType<AudioManager>().Play("Drink");
        }
    }
}
