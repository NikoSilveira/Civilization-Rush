using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downAttackTrigger : MonoBehaviour
{
    public int dmg = 1;
    private EnemyMovement enemy;
    private LargeDistanceEnemy distanceEnemy;


    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>();
        distanceEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<LargeDistanceEnemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Enemy"))
        {
            try
            {
                collision.SendMessageUpwards("Damage", dmg);
                enemy.Damage(dmg);
                distanceEnemy.Damage(dmg);
            } catch (System.NullReferenceException)
            {

            }
        }
    }
}
