using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowsPick : MonoBehaviour
{
    private PlayerPhone player;

    //Cantidad de flechas que obtiene
    public int arrowsObtained;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            //Recuperar cantidad de flechas establecidas en la variable arrowsObtained
            player.arrowCan += arrowsObtained;
            Destroy(gameObject);
        
            //SFX
            FindObjectOfType<AudioManager>().Play("Metal");
        }
    }
}
