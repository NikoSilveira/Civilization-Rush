﻿using System.Collections;
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
    public int myHealth;
    public int maxHealth = 100;
    public int myH;
    public int maxH = 5;

    //Shield
    public bool shield = false;
    public bool shieldActive = false;

    Animator anim;
    private Rigidbody2D rb;
    CapsuleCollider2D myBodyCollider2D;
    BoxCollider2D myBodyFeet;

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
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(speed);
        Flip();
        AnimationControl();
        

        // Movimiento a la izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!anim.GetBool("run"))
            {
                if(!shieldActive)
                {
                    speed = -speedX;
                } else
                {
                    speed = 0;
                }
            }
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }

        // Movimiento a la derecha
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(!anim.GetBool("run"))
            {
                if(!shieldActive)
                {
                   speed = speedX;
                } else
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
       if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            if (!myBodyFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                return;
            }
            if(!shieldActive)
            {
                Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
                rb.velocity += jumpVelocityToAdd;
            }
        }

        //Reiniciar
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);
        }

        //Salud
        if(myHealth > maxHealth)
        {
            myHealth = maxHealth;
            myH = maxH;
        }
        if(myHealth <= 0)
        {
            Die();
        }
        /*
        if (myHealth == 100)
        {
            myH = 5;
        }*/

        if (myHealth > 80 && myHealth <= 100)
        {
            myH = 5;
        }
        else if (myHealth > 60 && myHealth <= 80)
        {
            myH = 4;
        }
        else if (myHealth > 40 && myHealth <= 60)
        {
            myH = 3;
        }
        else if (myHealth > 20 && myHealth <= 40)
        {
            myH = 2;
        }
        else if (myHealth > 0 && myHealth <= 20)
        {
            myH = 1;
        }
        else if (myHealth <= 0)
        {
            myH = 0;
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

        //Debug.Log("Estado: "+shieldActive);

    }

    void MovePlayer(float playerSpeed)
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("walking_left", playerHasHorizontalSpeed);
        /*if (playerSpeed < 0 && playerSpeed > 0)
        {
            anim.SetBool("walking_left", true);
        }
        if(playerSpeed == 0)
        {
            anim.SetBool("walking_left", false);
        }*/
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
        if(!myBodyFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
        return;
        }
        if(CrossPlatformInputManager.GetButtonDown("Jump"))
        {
        Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
        rb.velocity += jumpVelocityToAdd;
        }
    }
    private void Flip()
    {
        if(Time.timeScale == 1)
        {
            if(speed > 0 && !facingRight || speed < 0 && facingRight)
            {
                facingRight = !facingRight;
                Vector3 temp = transform.localScale;
                temp.x *= -1;
                transform.localScale = temp;
            }
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

    public void playerBlock()
    {
        shieldActive = true;
        anim.SetBool("blocking", shieldActive);
    }

    public void playerDontBlock()
    {
        shieldActive = false;
        anim.SetBool("blocking", shieldActive);
    }
    public void Jump()
    {
        if(!shieldActive)
        {
            //rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            if (!myBodyFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                return;
            }
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            rb.velocity += jumpVelocityToAdd;
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void takeDamage(int damage)
    {
        if(shield == false || (shield == true && shieldActive == false)) //Condiciones para recibir daño
        {
            myHealth -= damage;
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

     
}

