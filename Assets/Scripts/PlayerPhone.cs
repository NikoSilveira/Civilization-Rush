using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhone : MonoBehaviour
{
    public float speedX;
    public float jumpSpeedY;

    bool facingRight, jumping;
    float speed;

    Animator anim;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(speed);

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
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
        }

    }

    void MovePlayer(float playerSpeed)
    {
        anim.SetBool("walking_left", true);
        if (playerSpeed < 0 && playerSpeed > 0)
        {
            anim.SetBool("walking_left", true);
        }
        if(playerSpeed == 0)
        {
            anim.SetBool("walking_left", false);
        }
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    void Flip()
    {
        if(speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp *= -1;
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
        rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
    }
}
