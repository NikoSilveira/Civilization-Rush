using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRange : MonoBehaviour
{

    public LargeDistanceEnemy enemy;
    public bool isLeft = false;
    private void Awake()
    {
        enemy = gameObject.GetComponentInParent<LargeDistanceEnemy>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isLeft)
            {
                enemy.attack(false);
            }
            else
            {
                enemy.attack(true);
            }
        }
    }
}
