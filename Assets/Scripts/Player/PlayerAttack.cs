using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    -Este script crea una variable de tipo playerPhone
    para poder establecer la lógica de ataque entre el
    jugador y los enemigos
*/

public class PlayerAttack : MonoBehaviour
{

    //------------------------------
    //          VARIABLES
    //------------------------------

    public Collider2D attackTrigger;
    private Animator anim;
    private PlayerPhone player;

    //Variables de control del ataque
    private bool attacking = false;
    private float attackTimer = 0;
    public float attackCd = 0.2f;

    //Spear
    public float spearAttackCd = 0.1f;
    public Collider2D spearAttackTrigger;
    public int weaponSelected = 1;
    private bool spearAttacking = false;

    //Downward attack
    private bool downattacking = false;
    public Collider2D downAttackTrigger;

    //Archer
    public float shootInterval;
    public float shootIntervalCd = 0.3f;
    public float arrowSpead = 100;
    public float arrowTimer;
    public GameObject arrow;
    public Transform shootPoint;
    private bool archerAttacking = false;

    //-------------------------------------------
    //     MÉTODOS PREDETERMINADOS DE UNITY
    //-------------------------------------------

    void Awake()
    {
        //Inicializar variables
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
        //Control del ataque, solo corre si el juego no está pausado
        if(Time.timeScale == 1)
        {
            downAttack();
            attack();
            switchWeapon();
        }
    }


    //-----------------------------------
    //    LÓGICA DE CONTROL DE ATAQUE
    //-----------------------------------

    //Ataque
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

            //Animación de ataque
            anim.SetBool("attacking", attacking);
        }
        else if (weaponSelected == 2)
        {
            if (Input.GetKeyDown("f") && !spearAttacking && player.myResistance >=0)
            {
                spearAttacking = true;
                attackTimer = spearAttackCd;
                //player.myResistance -= 1;
                spearAttackTrigger.enabled = true;
            }

            if (spearAttacking && player.myResistance >= 0)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    spearAttacking = false;
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
                spearAttacking = false;
                spearAttackTrigger.enabled = false;
            }

            //Animación de ataque
            anim.SetBool("attacking_spear", spearAttacking);
        }
        else if(weaponSelected == 3)
        {
            Vector2 direction;
                direction = shootPoint.transform.position - player.transform.position;


             
            direction.Normalize();

           if(Input.GetKeyDown("f") && !archerAttacking)
            {
                GameObject arrowClone;
                arrowClone = Instantiate(arrow, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
                arrowClone.GetComponent<Rigidbody2D>().velocity = direction * arrowSpead;
                shootInterval = shootIntervalCd;
                archerAttacking = true;
            }
           if(archerAttacking)
            {
                if(shootInterval > 0)
                {
                    shootInterval -= Time.deltaTime;
                }
                else
                {
                    archerAttacking = false;
                }
            }
        }
    }

    //Ataque hacia abajo
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
                Vector2 rejectVelocityToAdd = new Vector2(10, 0);
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
                }
            }
            anim.SetBool("attacking_down", downattacking);
        }
    }


    //-------------------------------
    //      LÓGICA DE BOTONES
    //-------------------------------

    //Botón de ataque - lógica
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
        else if (weaponSelected == 2 )
        {
            if (!spearAttacking && player.myResistance >= 0)
            {
                spearAttacking = true;
                attackTimer = spearAttackCd;
                player.myResistance -= 1;
                spearAttackTrigger.enabled = true;
            }
            else if (player.myResistance < 0)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                player.myResistance = 0;
                spearAttacking = false;
                spearAttackTrigger.enabled = false;
            }

            anim.SetBool("attacking_spear", spearAttacking);
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
        else if (weaponSelected == 2 && player.myResistance >= 0)
        {
            if (spearAttacking)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    spearAttacking = false;
                    spearAttackTrigger.enabled = false;
                }
            }
            else if (player.myResistance < 0)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                player.myResistance = 0;
                spearAttacking = false;
                spearAttackTrigger.enabled = false;
            }

            anim.SetBool("attacking_spear", spearAttacking);
        }
    }

    //Botón de ataque hacia abajo - lógica
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
            if (weaponSelected == 1)
            {
                if(player.spearF == true)
                {
                    weaponSelected = 2;
                }else if(player.spearF == false && player.archerP == true)
                {
                    weaponSelected = 3;
                }

            }
            else if(weaponSelected == 2)
            {
                if(player.archerP == false)
                {
                    weaponSelected = 1;
                }
                else if(player.archerP == true)
                {
                    weaponSelected = 3;
                }
            }
            else if(weaponSelected == 3)
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
