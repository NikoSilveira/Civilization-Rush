using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockPlayerTrigger : MonoBehaviour
{

    private PlayerPhone player;
    private EnemyMovement enemy;

    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Enemy"))
        {
            //collision.SendMessageUpwards("Damage", dmg);
            //enemy.Damage(dmg);
           
        }
    }
}
