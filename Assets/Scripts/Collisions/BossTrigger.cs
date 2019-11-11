using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * El boss trigger es un objeto sin sprite que cubre el acceso a la sala del jefe.
 * Es imposible pasar a la sala sin que se genere una colisión, la cual es detectada por este script
 */

public class BossTrigger : MonoBehaviour
{

    public Animator animator;

    //Colisión Jugador - BossTrigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Cambio de música
            FindObjectOfType<AudioManager>().Stop("Theme");
            FindObjectOfType<AudioManager>().Play("Boss");

            //Destruir el sprite
            Destroy(gameObject);

            //Activar el UI
            animator.SetBool("BattleActive", true);
        }
    }
}
