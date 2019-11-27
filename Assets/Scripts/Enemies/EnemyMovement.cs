using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//------------------------------------
//    CONTROL Y LÓGICA DEL ENEMIGO
//------------------------------------

/*
    -Este script crea un objeto de tipo playerPhone para poder
    obtener al jugador como objeto y poder establecer una lógica
    entre el enemigo y el jugador
 */

public class EnemyMovement : MonoBehaviour
{
    //--------------------------
    //        VARIABLES
    //--------------------------


    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigiBody;

    public Animator anim;
    public Rigidbody2D rigiBody2D;
    private PlayerPhone player;

    //Variables para el jefe
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
    public int maxHealth = 100;

    //Attack
    public float attackSpeed = 100;
    public float attacktimer;
    public float attackInterval;
    private float attackStartedAt = 0;

    public bool attackActive;
    public Transform attackLeft, attacKRight;

    //Instance Damage
    public int damageLevel;

    //Score
    public int Score;

    private Enemy enemy;


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


        //Daño de ataque
        EnemyFactory factory = new EnemyFactory();
        enemy = factory.getEnemy(EnemyTypes.medium);
        damageLevel = enemy.getAttPow();

        //Inicializar vida
        enemyHealth = enemy.getHealth();

        //Valor del enemigo
        Score = enemy.getScore();
    }

    // Update is called once per frame
    void Update()
    {

        // Al ver al jugador
        distancePlayer = target.position.x - transform.position.x;


        //Camine sin ver al jugador
        Move(rigiBody2D);

        //Muerte del enemigo
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
            player.Score += Score;

            //Muerte del jefe
            if(gate != null)
            {
                gate.SetActive(false);
                bossTrigger.StopBossBattle();
                FindObjectOfType<AudioManager>().Play("Scream");
            }
        }

        //Bara de vida del jefe
        if(enemyBar != null)
        {
            enemyBar.SetValueWithoutNotify(enemyHealth);
        }

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
        try
        {
            if (!collision.CompareTag("playerWeapon") && !collision.CompareTag("Player") && !collision.CompareTag("playerArrow"))
            {
                transform.localScale = new Vector2(-(Mathf.Sign(myRigiBody.velocity.x)), 1f);
            } else if(collision.CompareTag("playerWeapon"))
            {
                if(this.attackStartedAt == 0)
                {
                    attackStartedAt = Time.time;
                } else
                {
                    if(Time.time - attackStartedAt >= 2)
                    {
                        attackStartedAt = 0;
                        anim.SetFloat("Distance", 1);
                    } else
                    {
                        anim.SetFloat("Distance", 3);
                    }
                }
            }
        } catch (System.NullReferenceException) {

        }
    }

    //Cálculo de vida y daño
    public void Damage(int damage)
    {
        enemyHealth -= damage;
        FindObjectOfType<AudioManager>().Play("Inflict");
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

    public Enemy getEnemy()
    {
        return this.enemy;
    }
    public void RestartHealth()
    {
        this.enemyHealth = this.enemy.getHealth();
    }
}
