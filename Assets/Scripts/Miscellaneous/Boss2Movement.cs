using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2Movement : MonoBehaviour
{
    //--------------------------
    //        VARIABLES
    //--------------------------


    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigiBody;

    public Animator anim;
    public Rigidbody2D rigiBody2D;
    private PlayerPhone player;

    public Slider enemyBar;
    public GameObject gate;
    public BossTrigger bossTrigger;

    //Variables de posición, dirección y movimiento
    public Transform target;
    private float distancePlayer;
    private float maxSpeed = 5f;
    private Vector2 runRight;
    private Vector2 runLeft;
    private Vector2 stop;
    private bool facingRight = true;

    //Health
    public int enemyHealth;
    public int maxHealth;

    //Attack
    public float attackSpeed = 100;
    public float attacktimer;
    public float attackInterval;

    public bool attackActive;
    public Transform attackLeft, attacKRight;

    //Instance Damage
    public int damageLevel;

    //Score
    public int Score;


    //----------------------------------------
    //    MÉTODOS PREDETERMINADOS DE UNITY
    //----------------------------------------

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigiBody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigiBody = GetComponent<Rigidbody2D>();

        //Inicializar vectores de movimiento
        runRight = new Vector2(maxSpeed, 0);
        runLeft = new Vector2(-maxSpeed, 0);
        stop = new Vector2(0, 0);

        //Inicializar vida
        enemyHealth = maxHealth;

        //Valor del enemigo
        Score = 100;

        
    }

    // Update is called once per frame
    void Update()
    {

        // Al ver al jugador
        distancePlayer = target.position.x - transform.position.x;

        /*if(distancePlayer > 0 && !facingRight)
        {
            Flip();
        }
        else if(distancePlayer < 0 && facingRight)
        {
         Flip();
        }*/
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

        //Camine sin ver al jugador
        Move(rigiBody2D);

        //Muerte del enemigo
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            player.Score += Score;
            gate.SetActive(false);
            bossTrigger.StopBossBattle();
        }

        enemyBar.SetValueWithoutNotify(enemyHealth);
    }


    //----------------------
    //       MÉTODOS
    //----------------------

    private void FixedUpdate()
    {
        anim.SetFloat("Distance", Mathf.Abs(distancePlayer));
    }

    //Cambiar dirección
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    //Colisión del enemigo con un objeto
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("playerArrow"))
        {
            transform.localScale = new Vector2(-(Mathf.Sign(myRigiBody.velocity.x)), 1f);
        }
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

    //Recibir daño del jugador
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerPhone>().takeDamage(damageLevel);
            player.knockbackCount = player.knockbackLength;
            if(player.transform.position.x < transform.position.x)
            {
                player.knockbackRight = true;
            }
            else
            {
                player.knockbackRight = false;
            }
        }
    }*/

    //Cálculo de vida y daño
    public void Damage(int damage)
    {
        enemyHealth -= damage;
    }

    //Movimiento
    public void Move(Rigidbody2D body)
    {
        if (IsFacingRight())
        {
            body.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            body.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    //Funciones para el animador y el rigidbody

    public void setAnimator(Animator animator)
    {
        this.anim = animator;
    }

    public void setTarget(Transform target)
    {
        this.target = target;
    }

    public void setBody(Rigidbody2D rigidbody2D)
    {
        this.rigiBody2D = rigidbody2D;
    }
}
