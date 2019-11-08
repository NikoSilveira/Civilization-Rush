using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downAttackTrigger : MonoBehaviour
{
    public int dmg = 1;
    private EnemyMovement enemy;



    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("Damage", dmg);
            enemy.Damage(dmg);
        }
    }
}
