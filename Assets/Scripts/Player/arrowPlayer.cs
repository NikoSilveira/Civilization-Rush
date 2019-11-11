using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowPlayer : MonoBehaviour
{
    public int dmg = 1;
    private EnemyMovement enemy;
    private LargeDistanceEnemy distanceEnemy;


    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>();
        distanceEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<LargeDistanceEnemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true)
        {
            Debug.Log("dano");
            if (collision.CompareTag("Enemy"))
            {
                
                enemy.Damage(dmg);
                distanceEnemy.Damage(dmg);
            }
            if (!collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            }

        }
    }
}
