using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDistanceEnemy : MonoBehaviour
{
    //enemy live
    public int enemyHealth;
    public int maxEnemyHealth = 1;

    public float distance;
    public float enemyRange;
    public float shootInterval;
    public float arrowSpead = 100;
    public float arrowTimer;

    public bool range = false;
    public bool attacking = true;

    public GameObject arrow;
    public Transform target;
    public Animator enemyAnimator;
    public Transform shootPointLeft;
    public Transform shootPointRight;
    public BoxCollider2D box;

    //Score
    public int Score;

    private PlayerPhone player;

    private float distancePlayer;
    private bool facingRight = false;

    private Enemy enemy;


    private void Awake()
    {
        enemyAnimator = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    private void Start()
    {
        EnemyFactory factory = new EnemyFactory();
        enemy = factory.getEnemy(EnemyTypes.low);
        enemyHealth = enemy.getHealth();
        Score = enemy.getScore();

    }

    private void Update()
    {
        //enemyAnimator.SetBool("walk", range);
        //enemyAnimator.SetBool("shoot", attacking);

        TargetInRange();
        distancePlayer = target.position.x - transform.position.x;

        if (distancePlayer > 0 && !facingRight)
        {
            Flip();
        }
        else if (distancePlayer < 0 && facingRight)
        {

            Flip();
        }

        if (target.transform.position.x > transform.position.x)
        {
            
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            player.Score += Score;

        }
    }
    private void Flip()
    {
        Vector3 theScale1 = arrow.transform.localScale;
        theScale1.x *= -1;
        arrow.transform.localScale = theScale1;
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


  
    private void TargetInRange()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance< enemyRange)
        {
            range = true;
        }
        else
        {
            range = false;
        }
    }

    public void attack(bool attackRight)
    {
        arrowTimer += Time.deltaTime;

        if(arrowTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            if (!attackRight)
            {

                GameObject arrowClone;
                arrowClone = Instantiate(arrow, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                arrowClone.GetComponent<Rigidbody2D>().velocity = direction * arrowSpead;
                attacking = true;
                enemyAnimator.SetBool("shoot", attacking);
                arrowTimer = 0;

            }
     else if (attackRight)
            {
                GameObject arrowClone;
                arrowClone = Instantiate(arrow, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                arrowClone.GetComponent<Rigidbody2D>().velocity = direction * arrowSpead;
                attacking = true;
                enemyAnimator.SetBool("shoot", attacking);
                arrowTimer = 0;
            }
        }
        attacking = false;
        enemyAnimator.SetBool("shoot", attacking);
    }

    //Cálculo de vida y daño
    public void Damage(int damage)
    {
        enemyHealth -= damage;
        FindObjectOfType<AudioManager>().Play("Inflict");
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
