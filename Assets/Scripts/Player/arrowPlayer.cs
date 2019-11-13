using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowPlayer : MonoBehaviour
{
    public int dmg = 1;
    private EnemyMovement enemy;
    private LargeDistanceEnemy distanceEnemy;
    private float elimCd = 2f;
    private float elimIntervale;

    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>();
        distanceEnemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<LargeDistanceEnemy>();
    }

    private void Update()
    {
        if(elimIntervale > 0)
        {
            elimIntervale -= Time.deltaTime;
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true)
        {
            Debug.Log("dano");
            if (collision.CompareTag("Enemy"))
            {
                elimIntervale = elimCd;
                //enemy.Damage(dmg);
                //distanceEnemy.Damage(dmg);
                collision.GetComponent<EnemyMovement>().Damage(dmg);
                collision.GetComponent<LargeDistanceEnemy>().Damage(dmg);
                //Destroy(gameObject);
                
            }
            if (!collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
            

            Destroy(gameObject);

        }
    }
}
