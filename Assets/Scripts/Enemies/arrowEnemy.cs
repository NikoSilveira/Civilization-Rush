using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowEnemy : MonoBehaviour
{
    private PlayerPhone player;
    private int dmg;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
        EnemyFactory factory = new EnemyFactory();
        Enemy enemy = factory.getEnemy(EnemyTypes.low);
        dmg = enemy.getAttPow();
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
