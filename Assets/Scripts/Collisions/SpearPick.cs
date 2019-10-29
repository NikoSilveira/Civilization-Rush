using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    -Este script crea un objeto de tipo Playerphone para
    asignar la lanza al player
*/

public class SpearPick : MonoBehaviour
{
    private PlayerPhone player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }


    //Colisión Player - Lanza
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Obtener lanza, destruir sprite
            player.spearF = true;
            Destroy(gameObject);

            //SFX
            FindObjectOfType<AudioManager>().Play("Metal");
        }

    }
}
