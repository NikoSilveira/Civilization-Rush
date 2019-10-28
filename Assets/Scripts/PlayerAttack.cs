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

    //down attack
    private bool downattacking = false;
    public Collider2D downAttackTrigger;

    private PlayerPhone player;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
        spearAttackTrigger.enabled = false;
        downAttackTrigger.enabled = false;
        weaponSelected = 1;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            downAttack();
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
            if (Input.GetKeyDown("f") && !attacking && player.myResistance >=0)
            {

                attacking = true;
                attackTimer = spearAttackCd;
                player.myResistance -= 1;
                spearAttackTrigger.enabled = true;
            }

            if (attacking && player.myResistance >= 0)
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
            else if(player.myResistance < 0)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                player.myResistance = 0;
                attacking = false;
                spearAttackTrigger.enabled = false;
            }

            anim.SetBool("attacking", attacking);
        }
    }

    //Funcion de ataque hacia abajo
    public void downAttack()
    {
        if (weaponSelected == 1)
        {
            if (player.myBodyFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) == false && Input.GetKeyDown("h") && !downattacking)
            {
                Vector2 downVelocityToAdd = new Vector2(0f, -10f);
                player.rb.velocity += downVelocityToAdd;
                downattacking = true;
                attackTimer = attackCd;
                downAttackTrigger.enabled = true;
                Debug.Log("down");
            }
            if (player.myBodyFeet.IsTouchingLayers(LayerMask.GetMask("Enemy")) && downattacking == true)
            {
                Vector2 rejectVelocityToAdd = new Vector2(0.2f, 18f);
                player.rb.velocity += rejectVelocityToAdd;
            }
            if (downattacking)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    downattacking = false;
                    downAttackTrigger.enabled = false;
                    //StartCoroutine(player.Knockback(0.01f, 50, player.transform.position));
                }
            }
            anim.SetBool("attacking_down", downattacking);
        }
    }

    // Boton de ataque funciones logicas
    public void attackingButton()
    {
        if (weaponSelected == 1)
        {
            if (!attacking)
            {

                attacking = true;
                attackTimer = attackCd;

                attackTrigger.enabled = true;
            }

            anim.SetBool("attacking", attacking);
        }
        else if (weaponSelected == 2)
        {
            if (!attacking)
            {

                attacking = true;
                attackTimer = spearAttackCd;

                spearAttackTrigger.enabled = true;
            }

            anim.SetBool("attacking", attacking);
        }
    }

    public void dontAttackingButton()
    {
        if (weaponSelected == 1)
        {
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

    //boton de ataque hacia abajo funciones logicas
    public void downAttackingButton()
    {
        if(weaponSelected == 1)
        {
            if (player.myBodyFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) == false && !downattacking)
            {
                Vector2 downVelocityToAdd = new Vector2(0f, -10f);
                player.rb.velocity += downVelocityToAdd;
                downattacking = true;
                attackTimer = attackCd;
                downAttackTrigger.enabled = true;
                Debug.Log("down");

            }
            if (player.myBodyFeet.IsTouchingLayers(LayerMask.GetMask("Enemy")) && downattacking == true)
            {
                Vector2 rejectVelocityToAdd = new Vector2(0.2f, 18f);
                player.rb.velocity += rejectVelocityToAdd;
            }
            anim.SetBool("attacking_down", downattacking);
        }
    }

    public void dontdownAttackingButton()
    {
        if(weaponSelected == 1)
        {
            if (downattacking)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    downattacking = false;
                    downAttackTrigger.enabled = false;
                }
            }
            anim.SetBool("attacking_down", downattacking);
        }
    }

    // Boton de ataque
    public void attackButtom()
    {
        if(Time.timeScale == 1)
        {
            //attacking = true;
            // attackTimer = attackCd;

            //attackTrigger.enabled = true;
            attackingButton();
            //SFX
            FindObjectOfType<AudioManager>().Play("Swing");
        }

    }

    public void dontAttackButtom()
    {

        // attacking = false;
        //attackTrigger.enabled = false;
        dontAttackingButton();

    }

    //Boton hacia abajo
    public void downAttackButtow()
    {
        if(Time.timeScale == 1)
        {
            downAttackingButton();
        }
    }

    public void dontDownAttakButtow()
    {
        dontdownAttackingButton();
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

    //Cambio de arma boton
    public void buttonSwitchWeapon()
    {
        if (weaponSelected == 1 && player.spearF == true)
        {
            weaponSelected = 2;
        }
        else if (weaponSelected == 2)
        {
            weaponSelected = 1;
        }
    }

    public void dontSwitchWeaponButton()
    {
        return;
    }
}
