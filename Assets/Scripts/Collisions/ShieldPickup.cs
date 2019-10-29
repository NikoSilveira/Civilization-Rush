using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{

    PlayerPhone PlayerP;

    // Start is called before the first frame update
    void Start()
    {
        PlayerP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerP.shield = true;
            Destroy(gameObject);

            //SFX
            FindObjectOfType<AudioManager>().Play("Metal");
        }
    }

}
