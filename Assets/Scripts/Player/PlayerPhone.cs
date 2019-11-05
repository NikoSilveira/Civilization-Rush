using System.Collections;
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

    //Respawn
    public Vector3 respawnPoint;

    //Score
    public int Score;

    //Spear
    public bool spearF = false;

    //Resistance
    public int maxResistance = 5;
    public int myResistance;

    Animator anim;
    public Rigidbody2D rb;
    CapsuleCollider2D myBodyCollider2D;
    public BoxCollider2D myBodyFeet;


    //--------------------------------------------
    //      MÉTODOS PREDETERMINADOS DE UNITY
    //--------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        myBodyFeet = GetComponent<BoxCollider2D>();
        facingRight = true;

        //Health
        myHealth = maxHealth;
        myH = maxH;

        //Score
        Score = 0;

        //Resistance
        myResistance = maxResistance;

        //Guardar default values de atributos del jugador
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("CurrentStamina", 5);
        PlayerPrefs.SetInt("CurrentHealth", 9);
    }

    // Update is called once per frame
    void Update()
    {
        //Las funciones corren si el juego no está pausado
        if(Time.timeScale == 1)
        {
            MovePlayer(speed);
            Flip();
            AnimationControl();

            controlSalud();

            ControlConTeclado();

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
            if (myBodyFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                rb.velocity += jumpVelocityToAdd;
                return;
            }
        }
    }

    public void DontJump()
    {
        return;
    }

    private void Flip()
    {
        
        if(speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
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


    //------------------------
    //         ESCUDO
    //------------------------

    //Defender
    public void playerBlock()
    {
        if(!shieldActive)
        {
            shieldActive = true;
            anim.SetBool("blocking", shieldActive);
            speed = 0;
        }
    }

    //Al dejar de defender
    public void playerDontBlock()
    {
        shieldActive = false;
        anim.SetBool("blocking", shieldActive);
    }



    //-----------------------
    //         SALUD
    //-----------------------

    public void Die()
    {
        //Reaparecer
        transform.position = respawnPoint;

        //Recuperar los ultimos atributos guardados
        myHealth = PlayerPrefs.GetInt("CurrentHealth");
        Score = PlayerPrefs.GetInt("CurrentScore");
        myResistance = PlayerPrefs.GetInt("CurrentStamina");

        //SFX
        FindObjectOfType<AudioManager>().Play("Death");
    }

    public void takeDamage(int damage)
    {
        if(shield == false || (shield == true && shieldActive == false)) //Condiciones para recibir daño
        {
            myHealth -= damage;
            anim.SetBool("hurting",true);
            hurtTime = (int)Time.time;
        }
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


    //----------------------------------
    //    CONTROLADOR DE ANIMACIONES
    //----------------------------------

    void AnimationControl()
    {
        if(shield == false)
        {
            //Activar animaciones estándar
            anim.SetLayerWeight(1,0);
        }
        else if(shield == true)
        {
            //Activar animaciones con escudo
            anim.SetLayerWeight(1,1);
        }
    }

}

