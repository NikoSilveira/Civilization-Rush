using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerPhone : MonoBehaviour
{
    public float speedX;
    //public float jumpSpeedY;
    [SerializeField] float jumpSpeed = 5f;

    bool isAlive = true;

    bool facingRight, jumping;
    float speed;

    Animator anim;
    Rigidbody2D rb;
    Collider2D myCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<Collider2D>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(speed);
        Flip();
        

        // Movimiento a la izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -speedX;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }

        // Movimiento a la derecha
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = speedX;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }

       //Salto
       if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                return;
            }
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            rb.velocity += jumpVelocityToAdd;
        }
     
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
        if(!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
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
        speed = -speedX;
    }

    public void WalkRight()
    {
        speed = speedX;
    }

    public void StopMoving()
    {
        speed = 0;
    }

    public void Jump()
    {
        //rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
        rb.velocity += jumpVelocityToAdd;
    }
}
