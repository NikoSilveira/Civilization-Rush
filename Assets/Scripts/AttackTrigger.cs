using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int dmg = 50;
    private EnemyMovement enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger != true && collision.CompareTag("Enemy"))
        {
            try
            {
                collision.SendMessageUpwards("Damage", dmg);
                enemy.Damage(dmg);
            } catch(System.NullReferenceException ex)
            {

            }
        }
    }
}
