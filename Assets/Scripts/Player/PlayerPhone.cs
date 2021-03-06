﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

//-------------------------------
//      SCRIPT DEL JUGADOR
//-------------------------------

public class PlayerPhone : MonoBehaviour
{

    //-------------------
    //     VARIABLES
    //-------------------

    public float speedX;
    
    [SerializeField] float jumpSpeed = 5f;

    bool facingRight, jumping;
    float speed;
    //public float jumpSpeedY;

    bool isAlive = true;

    //Health
    private int hurtTime;
    public int myHealth;
    public int maxHealth = 9;
    public int myH;
    public int maxH = 9;

    //Shield
    public bool shield = false;
    public bool shieldActive = false;

    //Iframes
    private bool IframesActive = false;

    //Respawn
    public Vector3 respawnPoint;
    public bool checkpointReached = false;

    //Score
    public int Score;

    //Spear
    public bool spearF = false;

    //Archer
    public bool archerP = false;

    //Resistance
    public int maxResistance = 5;
    public int myResistance;

    //Arrows
    public int arrowCanIn;
    public int arrowCan;
    public GameObject arrowPlayer;

    //Animadores
    Animator anim;

    public Rigidbody2D rb;
    CapsuleCollider2D myBodyCollider2D;
    public BoxCollider2D myBodyFeet;

    //Retroceso al ser golpeado
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockbackRight;

    //jump
    private float jumpCd = 0.3f;
    private float jumpTime = 2f;
    private bool jumpbool = false;

    private float jumpStart = 0f;
    private Vector2 ccOffset;

    public CheckpointController checkpointC;
    public GameObject enemyParameter;

    //--------------------------------------------
    //      MÉTODOS PREDETERMINADOS DE UNITY
    //--------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        //Elementos del inspector - inicializar
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        ccOffset = myBodyCollider2D.offset;
        myBodyFeet = GetComponent<BoxCollider2D>();
        facingRight = true;

        //Health
        myHealth = maxHealth;
        myH = maxH;

        //Score
        Score = 0;

        //Resistance
        myResistance = maxResistance;

        //Arrow
        arrowCan = arrowCanIn;

        //Guardar default values de atributos del jugador
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("CurrentStamina", 5);
        PlayerPrefs.SetInt("CurrentHealth", 9);

        //Checkpoint
        //checkpointC = FindObjectOfType<Checkpoints>
        //checkpointC = FindGameObjectOfType<Checkpoints>.GetComponent<PlayerPhone>();
    }

    // Update is called once per frame
    void Update()
    {
        //Las funciones corren si el juego no está pausado
        if(Time.timeScale == 1)
        {
            if(knockbackCount <= 0)
            {
                MovePlayer(speed);
                ControlConTeclado();
            }else
            {
                if (knockbackRight)
                {
                    rb.velocity = new Vector2(-knockback, knockback);
                }
                if (!knockbackRight)
                {
                    rb.velocity = new Vector2(knockback, knockback);
                }
                knockbackCount -= Time.deltaTime;

            }

            if (jumpStart != 0f)
            {
                //Debug.Log(Time.time - jumpStart);
                if (Time.time - jumpStart >= jumpTime)
                {
                    anim.SetBool("jumping", false);
                    jumpStart = 0f;
                }
            }
            /*if(anim.GetBool("archer"))
            {
                myBodyCollider2D.offset = new Vector2(ccOffset.x, -1.22f);
            } else
            {
                myBodyCollider2D.offset = ccOffset;
            }*/

            Flip();

            controlSalud();

            

            CheckHurtingState();
        }
    }



    //---------------------------------
    //     CONTROLES CON TECLADO
    //---------------------------------

    void ControlConTeclado()
    {
        // Movimiento a la izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!anim.GetBool("run"))
            {
                if (!shieldActive)
                {
                    speed = -speedX;
                }
                else
                {
                    speed = 0;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }

        // Movimiento a la derecha
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!anim.GetBool("run"))
            {
                if (!shieldActive)
                {
                    speed = speedX;
                }
                else
                {
                    speed = 0;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }

        //Salto
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            //rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            if (!myBodyFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                return;
            }
            if (!shieldActive)
            {
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                rb.velocity += jumpVelocityToAdd;
                anim.SetBool("jumping", true);
                if (myBodyFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
                {
                    anim.SetBool("jumping", false);
                }
            }


        }

        //Escudo
        if (Input.GetKeyDown(KeyCode.D))
        {
            shieldActive = true;
            anim.SetBool("blocking", shieldActive);
            speed = 0;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            shieldActive = false;
            anim.SetBool("blocking", shieldActive);
        }

    }



    //--------------------------
    //        MOVIMIENTO
    //--------------------------

        //Funciones: MovePlayer, Jump, DontJump, Flip, WalkLeft, WalkRight, StopMoving (setter)

    void MovePlayer(float playerSpeed)
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("walking_left", playerHasHorizontalSpeed);
        if (playerSpeed < 0 || playerSpeed > 0)
        {
            anim.SetBool("walking_left", true);
        }
        if(playerSpeed == 0)
        {
            anim.SetBool("walking_left", false);
        }
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    /*private void Run()
     {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * speedX, rb.velocity.y);
        rb.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("walking_left", playerHasHorizontalSpeed);
    }*/

    public void Jump()
    {
        if (Time.timeScale == 1 && !shieldActive)
        {
            //rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            if (myBodyFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) && !jumpbool)
            {
                
                jumpbool = true;
                jumpTime = jumpCd;
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                rb.velocity += jumpVelocityToAdd;
                
                //return;
                anim.SetBool("jumping", jumpbool);
                jumpStart = Time.time; // The time when player starts jumping
            }

        }
    }

    public void DontJump()
    {
        //Debug.Log("cancel test");
        if (jumpbool)
        {
            
                jumpbool = false;
        }
        anim.SetBool("jumping", jumpbool);
        //return;
    }

    private void Flip()
    {
        
        if(speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            Vector3 theScale1 = arrowPlayer.transform.localScale;
            theScale1.x *= -1;
            arrowPlayer.transform.localScale = theScale1;
            
        }
        
    }

    public void WalkLeft()
    {
        if(!shieldActive)
        {
           speed = -speedX;
        }
        return;
    }

    public void WalkRight()
    {
        if (!shieldActive)
        {
            speed = speedX;
        }
    }

    public void StopMoving()
    {
        speed = 0;
    }



    //-----------------------
    //         SALUD
    //-----------------------

    //Funciones: Die, Respawn, TakeDamage, CheckHurtingState, DeactivateIFrames, Knockback, controlSalud

    public void Die()
    {
        //SFX
        FindObjectOfType<AudioManager>().Play("Death");

        //Llamar funcion para revivir y normalizar tiempo
        Invoke("Respawn", 0.5f);
        StopMoving();

        //Desacelerar tiempo
        Time.timeScale = 0.3f;
    }

    //Revivir
    public void Respawn()
    {
        myHealth = PlayerPrefs.GetInt("CurrentHealth");
        myResistance = PlayerPrefs.GetInt("CurrentStamina");

        Time.timeScale = 1;
        transform.position = respawnPoint;
        StopMoving();
    }

    public void takeDamage(int damage)
    {
        if (IframesActive)  //Si hay iframes activos, retornar
        {
            return;
        }

        if(shield == false || (shield == true && shieldActive == false)) //Condiciones para recibir daño (escudo)
        {
            //Recibir daño
            myHealth -= damage;
            anim.SetBool("hurting",true);
            hurtTime = (int)Time.time;

            //SFX
            FindObjectOfType<AudioManager>().Play("Auch");

            //Activar Iframes
            IframesActive = true;
            Invoke("DeactivateIFrames", 0.75f);
        }
    }

    //Llamar esta funcion con un invoke para generar un delay
    public void DeactivateIFrames()
    {
        IframesActive = false;
    }

    public void CheckHurtingState()
    {
        if(anim.GetBool("hurting") == true)
        {
            if((int)Time.time - hurtTime == 1)
            {
                anim.SetBool("hurting", false);
            }
        }
    }

    public IEnumerator Knockback(float knockDur, float knockbackpwe, Vector3 knockbackDir)
    {
        float timer = 0;
        while( knockDur > timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackpwe, transform.position.z));
        }
        
        yield return 0;
    }

    public void controlSalud()
    {
        //Salud
        if (myHealth > maxHealth)
        {
            myHealth = maxHealth;
            myH = maxH;
        }
        if (myHealth <= 0)
        {
            Die();
        }

        myH = myHealth;
 
    }

}

