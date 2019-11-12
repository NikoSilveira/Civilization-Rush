using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archerPickUp : MonoBehaviour
{
    private PlayerPhone player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }


    //Colisión Player - Arco
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Obtener arco, destruir objeto arco
            player.archerP = true;
            Destroy(gameObject);

            //SFX
            FindObjectOfType<AudioManager>().Play("Metal");
        }

    }
}
