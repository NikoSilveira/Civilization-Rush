using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Collider2D enemyAttackTrigger;
    private PlayerPhone player;
    public EnemyMovement enemy;
    private Animator anim;
    private float distancePlayer;
    private float attackCD = 1.5f;
    private float attackIntervale;
    private float attackDuration;
    private float attackDurationCd = 0.4f;
    private bool enemyAttacking;
    // public Transform playerTarget;
    //public Transform enemyTransform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovement>();
        enemyAttackTrigger.enabled = false;
        anim = GetComponent<Animator>();
        attackIntervale = 0;
        enemyAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        distancePlayer = player.transform.position.x - enemy.transform.position.x;
        enemyAttack();
    }

    private void enemyAttack()
    {
        if(attackIntervale > 0)
        {
            anim.SetFloat("Distance", 4);
            attackIntervale -= Time.deltaTime;

        }
        else
        {
            if (enemy.rigiBody2D.IsTouchingLayers(LayerMask.GetMask("Player")))
            {
                Debug.Log("player");
                enemyAttackTrigger.enabled = true;
                enemyAttacking = true;
                attackDuration = attackDurationCd;
            }
            if (enemyAttacking)
            {
                if (attackDuration > 0)
                {
                    attackDuration -= Time.deltaTime;
                }
                else
                {
                    enemyAttacking = false;
                    enemyAttackTrigger.enabled = false;
                    
                    attackIntervale = attackCD;
                }
            }
            anim.SetFloat("Distance", Mathf.Abs(distancePlayer));

        }
    }
}
