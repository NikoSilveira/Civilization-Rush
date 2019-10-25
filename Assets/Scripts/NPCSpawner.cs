using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    //Low power enemy
    public Animator lpEnemyAnimator;
    public BoxCollider2D lpBodyFeet;
    public CapsuleCollider2D lpBodyCollider;
    public Rigidbody2D lpRigidBody;
    public float lpSpeed;

    //Medium power enemy
    public Animator mpEnemyAnimator;
    public BoxCollider2D mpBodyFeet;
    public CapsuleCollider2D mpBodyCollider;
    public Rigidbody2D mpRigidBody;
    public float mpSpeed;

    //High power enemy
    public Animator hpEnemyAnimator;
    public BoxCollider2D hpBodyFeet;
    public CapsuleCollider2D hpBodyCollider;
    public Rigidbody2D hpRigidBody;
    public float hpSpeed;
    private float[] firstLvlYPositions;

    // Start is called before the first frame update
    void Start()
    {
        firstLvlYPositions = new float[] { 
            -2.8f, -0.91f, 2.12f, -3.85f, 
            2.09f, -6.9f, 0.11f, 2.11f, 
            -22.9f, -21.89f, -23.9f, 3.09f, 
            9.11f, 6.1f, -4.93f, 0.08f, -10.94f, 
            -9.94f };
        float positionX = Random.Range(30f, 590f);
        float positionY = 0f;
        if(positionX >= 30f && positionX <= 56f)
        {
            positionY = firstLvlYPositions[0];
        } else if(positionX >= 61f && positionX <= 73f)
        {
            positionY = firstLvlYPositions[1];
        } else if(positionX >= 77.5f && positionX <= 123f)
        {
            positionY = firstLvlYPositions[2];
        } else if(positionX >= 134.5f && positionX <= 205.5f)
        {
            if(positionX <= 159f)
            {
                int selecter = (int)Random.Range(0f, 1f);
                if(selecter == 0)
                {
                    positionY = firstLvlYPositions[3];
                } else
                {
                    positionY = firstLvlYPositions[4];
                }
            } else
            {
                positionY = firstLvlYPositions[3];
            }
        } else if(positionX >= 169f && positionX <= 205.5f)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public abstract class Enemy
    {
        public int health;
        public int attPow;
        public abstract void Move();
        public abstract void Attack();
    }

    public class LowPowerEnemy : Enemy
    {
        public LowPowerEnemy()
        {
            health = 5;
            attPow = 1;
        }
        public override void Move()
        {
        }
        public override void Attack()
        {
        }
    }
    
    public class MediumPowerEnemy : Enemy
    {
        public MediumPowerEnemy()
        {
            health = 10;
            attPow = 3;
        }
        public override void Move()
        {
        }
        public override void Attack()
        {
        }
    }

    public class HighPowerEnemy : Enemy
    {
        public HighPowerEnemy()
        {
            health = 15;
            attPow = 5;
        }
        public override void Move()
        {
        }
        public override void Attack()
        {
        }
    }

    public abstract class NPCFactory
    {
        public abstract Enemy getEnemy(EnemyTypes type);
    }

    public class EnemyFactory : NPCFactory
    {
        public override Enemy getEnemy(EnemyTypes type)
        {
            switch(type)
            {
                case EnemyTypes.flying:
                    return new FlyingEnemy();
                default:
                    return null;
            }
        }
    }

    public enum EnemyTypes
    {
        low = 0,
        medium = 1,
        high = 2
    }

}
