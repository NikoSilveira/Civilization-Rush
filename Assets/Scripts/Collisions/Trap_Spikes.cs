using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Este script crea un objeto de tipo PlayerPhone para poder
    generar la interacción con las púas, la cual requiere
    manipular vida y vectores del jugador
 */

public class Trap_Spikes : MonoBehaviour
{
    private PlayerPhone player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Colisión Player - spikes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Recibir daño/knockback
            player.takeDamage(1);

            StartCoroutine(player.Knockback(0.2f, 250, player.transform.position));
        }
    }
}
