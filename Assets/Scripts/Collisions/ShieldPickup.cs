using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    -Este script crea un objeto que instancia a 
    PlayerPhone para activar el escudo del jugador
 */

public class ShieldPickup : MonoBehaviour
{

    PlayerPhone PlayerP;

    // Start is called before the first frame update
    void Start()
    {
        PlayerP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }


    //Colisión jugador - escudo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Asignar escudo a player
            PlayerP.shield = true;
            Destroy(gameObject);

            //SFX
            FindObjectOfType<AudioManager>().Play("Metal");
        }
    }

}
