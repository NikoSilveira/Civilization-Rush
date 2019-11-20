using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerPhone player;
    private EnemyMovement enemy;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
        enemy = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Player"))
        {
            //collision.GetComponent<PlayerPhone>().takeDamage(enemy.damageLevel);
            try
            {
                player.takeDamage(enemy.damageLevel);
                player.knockbackCount = player.knockbackLength;
                if (player.transform.position.x < transform.position.x)
                {
                    player.knockbackRight = true;
                }
                else
                {
                    player.knockbackRight = false;
                }
            } catch (System.NullReferenceException)
            {

            }
        }
    }
}
