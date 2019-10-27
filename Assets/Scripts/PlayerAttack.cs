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

    //Spear
    public float spearAttackCd = 0.6f;
    public Collider2D spearAttackTrigger;
    public int weaponSelected = 1;

    private PlayerPhone player;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
        spearAttackTrigger.enabled = false;
        weaponSelected = 1;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            attack();
            switchWeapon();
        }
            

    }

    //Funcion de ataque
    public void attack()
    {
        if (weaponSelected == 1)
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
        else if (weaponSelected == 2)
        {
            if (Input.GetKeyDown("f") && !attacking)
            {

                attacking = true;
                attackTimer = spearAttackCd;

                spearAttackTrigger.enabled = true;
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
                    spearAttackTrigger.enabled = false;
                }
            }

            anim.SetBool("attacking", attacking);
        }
    }


    // Boton de ataque
    public void attackButtom()
    {
        if(Time.timeScale == 1)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;

            //SFX
            FindObjectOfType<AudioManager>().Play("Swing");
        }

    }

    public void dontAttackButtom()
    {
      
        attacking = false;
       attackTrigger.enabled = false;

    }

    //Cambio de arma
    public void switchWeapon()
    {
        if (Input.GetKeyDown("c"))
        {
            if (weaponSelected == 1 && player.spearF == true)
            {
                weaponSelected = 2;
            }
            else if(weaponSelected == 2)
            {
                weaponSelected = 1;
            }
        }
    }
}
