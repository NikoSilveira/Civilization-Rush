using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowEnemy : MonoBehaviour
{
    private PlayerPhone player;
    public int dmg;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger != true)
        {
            if (collision.CompareTag("Player"))
            {
                player.takeDamage(dmg);
                //collision.GetComponent<PlayerPhone>().takeDamage(1);
            }

            Destroy(gameObject);
        }
    }
}
