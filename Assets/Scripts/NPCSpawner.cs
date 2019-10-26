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
            -2.8f, //0
            -0.91f, //1
            2.12f, //2
            -3.85f,//3
            2.09f, //4
            -6.9f, //5
            0.11f, //6
            2.11f,//7
            -22.9f, //8
            -21.89f, //9
            -23.94f, //10
            3.09f,//11
            9.11f, //12
            6.1f, //13
            -4.93f, //14
            0.08f, //15
            -10.94f,//16
            -9.94f, //17
            0.07f
        }; //18
        float positionX = Random.Range(30f, 590f);
        float positionY = 0f;
        if (positionX >= 30f && positionX <= 56f)
        {
            positionY = firstLvlYPositions[0];
        }   else if (positionX >= 61f && positionX <= 73f)
        {
            positionY = firstLvlYPositions[1];
        }   else if (positionX >= 77.5f && positionX <= 123f)
        {
            positionY = firstLvlYPositions[2];
        }   else if (positionX >= 134.5f && positionX <= 205.5f)
        {
            if (positionX <= 159f)
            {
                int selecter = (int)Random.Range(0f, 1f);
                if (selecter == 0)
                {
                    positionY = firstLvlYPositions[3];
                }   else
                {
                    positionY = firstLvlYPositions[4];
                }
            }   else
            {
                positionY = firstLvlYPositions[3];
            }
        } else if (positionX >= 216f && positionX <= 227f)
        {
            positionY = firstLvlYPositions[5];
        } else if(positionX >= 277f && positionX <= 333f)
        {
            positionY = firstLvlYPositions[6];
        } else if(positionX>= 340.5f && positionX <= 354f)
        {
            positionY = firstLvlYPositions[7];
        } else if(positionX >= 394.5f && positionX <= 397.5f)
        {
            positionY = firstLvlYPositions[8];
        } else if(positionX >= 401f && positionX <= 405.5f)
        {
            positionY = firstLvlYPositions[9];
        } else if((positionX >= 412f && positionX <= 426f))
        {
            positionY = firstLvlYPositions[10];
        } else if(positionX >= 436.2f && positionX <= 533f)
        {
            positionY = firstLvlYPositions[10];
            if(positionX >= 455.26 && positionX <= 456.7)
            {
                int selecter = (int)Random.Range(0f, 3f);
                switch(selecter)
                {
                    case 0:
                        positionY = firstLvlYPositions[14];
                        break;
                    case 1:
                        positionY = firstLvlYPositions[11];
                        break;
                    case 2:
                        positionY = firstLvlYPositions[12];
                        break;
                    case 3:
                        positionY = firstLvlYPositions[10];
                        break;
                }
            } else if(positionX >= 470.55f && positionX <= 471.2f)
            {
                int selecter = (int)Random.Range(0f, 3f);
                switch (selecter)
                {
                    case 0:
                        positionY = firstLvlYPositions[13];
                        break;
                    case 1:
                        positionY = firstLvlYPositions[18];
                        break;
                    case 2:
                        positionY = firstLvlYPositions[14];
                        break;
                    case 3:
                        positionY = firstLvlYPositions[10];
                        break;
                }
            } else if(positionX >= 479f && positionX <= 504.29f)
            {

            }
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
            return null;
        }
    }

    public enum EnemyTypes
    {
        low = 0,
        medium = 1,
        high = 2
    }

}
