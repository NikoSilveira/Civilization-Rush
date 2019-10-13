using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigiBody;

    public Transform target;
    private float distancePlayer;
    private Animator anim;
    private Rigidbody2D rigiBody2D;
    private float maxSpeed = 5f;
    private Vector2 runRight;
    private Vector2 runLeft;
    private Vector2 stop;
    private bool facingRight = true;

    //health
    public int enemyHealth;
    public int maxHealth = 100;

    public float attackSpeed = 100;
    public float attacktimer;
    public float attackInterval;

    public bool attackActive;
    public Transform attackLeft, attacKRight;

    private PlayerPhone player;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigiBody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigiBody = GetComponent<Rigidbody2D>();

        runRight = new Vector2(maxSpeed, 0);
        runLeft = new Vector2(-maxSpeed, 0);
        stop = new Vector2(0, 0);

        //Health
        maxHealth = 100;
        enemyHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

     

        // Al ver al jugador
        distancePlayer = target.position.x - transform.position.x;
        if(distancePlayer > 0 && !facingRight)
        {
            Flip();
        }
        else if(distancePlayer < 0 && facingRight)
        {
         Flip();
        }
        /*
        if(distancePlayer < -1f)
        {
            rigiBody2D.velocity = runLeft;
        }
        else if(distancePlayer > 1f)
        {
            rigiBody2D.velocity = runRight;
        }
        else
        {
            myRigiBody.velocity = stop;
        } */

        // Camine sin ver al jugador
        if (IsFacingRight())
        {
            rigiBody2D.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rigiBody2D.velocity = new Vector2(-moveSpeed, 0);
        }

        //enemy die
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }


    }

    private void FixedUpdate()
    {
        anim.SetFloat("Distance", Mathf.Abs(distancePlayer));
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigiBody.velocity.x)), 1f);
    }


    /*public void attack(bool attackingRight)
    {
        attacktimer += Time.deltaTime;

        if(attacktimer >= attackInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (!attackingRight)
            {

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger != true)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerPhone>().takeDamage(20);
      
            }
        }
    }

    public void Damage(int damage)
    {
        enemyHealth -= damage;
    }


}
