using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private bool attacking = false;
    private float attackTimer = 0;
    public float attackCd = 0.2f;

    public Collider2D attackTrigger;
    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            if (Input.GetKeyDown("f") && !attacking)
            {

                attacking = true;
                attackTimer = attackCd;

                attackTrigger.enabled = true;
            }

            if (attacking)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    attacking = false;
                    attackTrigger.enabled = false;
                }
            }

            anim.SetBool("attacking", attacking);
        }

    }

    public void attackButtom()
    {
        if(Time.timeScale == 1)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }

    }

    public void dontAttackButtom()
    {
       
                attacking = false;
                attackTrigger.enabled = false;
            
    }

}
