using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttackTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 3;
    private EnemyMovement enemy;
    private LargeDistanceEnemy distanceEnemy;

    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>();
        distanceEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<LargeDistanceEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("Damage", damage);
            enemy.Damage(damage);
            distanceEnemy.Damage(damage);
        }
    }

}
