using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    -Este script es utilizado por PlayerPhone para 
    obtener la variable de control del checkpoint
    -PlayerPhone responde guardando un vector3 de la posición
    del jugador durante la colisión con el checkpoint
*/

public class CheckpointController : MonoBehaviour
{

    private PlayerPhone player;

    //Control dinámico del sprite
    public Sprite redFlag;
    public Sprite blueFlag;
    private SpriteRenderer checkpointSpriteRenderer;

    //Bool de control de activación del checkpoint
    public bool checkpointReached;



    // Start is called before the first frame update
    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Colisión Player - Checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && checkpointSpriteRenderer.sprite == redFlag)
        {
            //Activar checkpoint
            checkpointSpriteRenderer.sprite = blueFlag;
            checkpointReached = true;

            //Registrar posición en variables de player
            player.respawnPoint = collision.transform.position;
            player.checkpointActivated = true;

            //SFX
            FindObjectOfType<AudioManager>().Play("Checkpoint");
        }
    }
}
