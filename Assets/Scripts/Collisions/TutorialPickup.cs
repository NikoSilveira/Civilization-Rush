using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPickup : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }


    //Colisión Jugador - LibroTutorial
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            //Activar cuadro de diálogo
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();

            //SFX
            FindObjectOfType<AudioManager>().Play("Book");

            //Destruir el sprite
            Destroy(gameObject);
        }
    }

}
