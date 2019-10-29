using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerPhone : MonoBehaviour
{
    public float speedX;
    //public float jumpSpeedY;
    [SerializeField] float jumpSpeed = 5f;

    bool isAlive = true;

    bool facingRight, jumping;
    float speed;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            MovePlayer(speed);
            Flip();
            AnimationControl();

            controlSalud();

            ControlConTeclado();

            CheckHurtingState();
        }


        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);
        }*/



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

        //Reiniciar
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }



    //--------------------------
    //        MOVIMIENTO
    //--------------------------

    void MovePlayer(float playerSpeed)
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("walking_left", playerHasHorizontalSpeed);
        if (playerSpeed < 0 || playerSpeed > 0) //Habilité estos dos ifs para resolver el problema. Era or, no and
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

    private void jump()
    { 
        if(Time.timeScale == 1)
        {
            if (!myBodyFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                return;
            }
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                rb.velocity += jumpVelocityToAdd;
            }
        }

    }
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

    public void playerBlock()
    {
        if(!shieldActive)
        {
            shieldActive = true;
            anim.SetBool("blocking", shieldActive);
            speed = 0;
        }
    }

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
        //SceneManager.LoadScene("SampleScene");
        transform.position = respawnPoint;
        myHealth = maxHealth;
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

    public void controlSalud()  //INTENTAR LIMPIAR UN POCO EL SISTEMA DE CONDICIONALES
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
        /*
        if (myHealth == 100)
        {
            myH = 5;
        }*/

        if (myHealth == 9)
        {
            myH = 9;
        }
        else if (myHealth == 8)
        {
            myH = 8;
        }
        else if (myHealth == 7)
        {
            myH = 7;
        }
        else if (myHealth == 6)
        {
            myH = 6;
        }
        else if (myHealth == 5)
        {
            myH = 5;
        }
        else if(myHealth == 4)
        {
            myH = 4;
        }
        else if(myHealth == 3)
        {
            myH = 3;
        }
        else if(myHealth == 2)
        {
            myH = 2;
        }
        else if (myHealth==1)
        {
            myH = 1;
        }
        else if (myHealth <= 0)
        {
            myH = 0;
        }
    }



    //----------------------------------
    //    CONTROLADOR DE ANIMACIONES
    //----------------------------------

    void AnimationControl()
    {
        if(shield == false)
        {
            anim.SetLayerWeight(1,0);
        }
        else if(shield == true)
        {
            anim.SetLayerWeight(1,1);
        }
    }




    //-----------------------------
    //         CHECKPOINT
    //-----------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            respawnPoint = collision.transform.position;
        }
    }

}

