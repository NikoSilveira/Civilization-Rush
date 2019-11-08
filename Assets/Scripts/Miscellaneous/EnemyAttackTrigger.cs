using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerPhone player;
    private EnemyMovement enemy;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerPhone>().takeDamage(enemy.damageLevel);
        }
    }
}
