using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger != true)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerPhone>().takeDamage(1);
            }

            Destroy(gameObject);
        }
    }
}
