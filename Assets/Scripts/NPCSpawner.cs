using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    //Low power enemy
    public Animator lpEnemyAnimator;
    public Sprite lpSprite;
    //Medium power enemy
    public Animator mpEnemyAnimator;
    public Sprite mpSprite;
    //High power enemy
    public Animator hpEnemyAnimator;
    public Sprite hpSprite;

    private float[] firstLvlYPositions;
    public int enemiesQuantity;
    private Enemy[] enemies;
    public Transform enemiesTarget;
    private GameObject[] sr;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new Enemy[enemiesQuantity];
        sr = new GameObject[enemiesQuantity];
        EnemyFactory enemyFactory = new EnemyFactory();
        for (int i = 0; i < enemiesQuantity; i++)
        {
            Vector3 sectorData = generatePosition(0, 0);
            float x = sectorData.x;
            float y = sectorData.y;
            int enemiesCounter = (int)sectorData.z;
            sr[i] = new GameObject();
            sr[i].name = "Enemy " + i;
            sr[i].tag = "Enemy";
            sr[i].transform.position = new Vector3(x, y, 0);
            sr[i].layer = 10;

            // Animator 
            Animator animator = sr[i].AddComponent<Animator>();
            animator.runtimeAnimatorController = GetComponent<Animator>().runtimeAnimatorController;

            // Sprite Renderer
            SpriteRenderer spriteR = sr[i].AddComponent<SpriteRenderer>();
            spriteR.sprite = lpSprite;
            spriteR.sortingLayerName = "Enemy";

            // Rigid Body
            Rigidbody2D enemyBody = sr[i].AddComponent<Rigidbody2D>();

            // Move Controller
            EnemyMovement move = sr[i].AddComponent<EnemyMovement>();
            move.setTarget(enemiesTarget);
            move.anim = animator;
            move.setBody(enemyBody);

            // Capsule Collider
            CapsuleCollider2D collider = sr[i].AddComponent<CapsuleCollider2D>();
            collider.size = new Vector2(2.19f, 2.19f);
            collider.direction = CapsuleDirection2D.Vertical;

            // Box Collider
            BoxCollider2D box = sr[i].AddComponent<BoxCollider2D>();
            box.isTrigger = true;
            box.size = new Vector2(0.63f, 1.05f);
            box.offset = new Vector2(0.78f, -1.02f);

            // Instance Functions
            enemies[i] = enemyFactory.getEnemy(sr[i], EnemyTypes.low);
            enemies[i].initAnimator();
            enemies[i].setTarget(enemiesTarget);
            enemies[i].setBodyType(RigidbodyType2D.Kinematic);
            enemies[i].setEnemyPosition(x, y, 0);
        }
    }
    public abstract class NPCFactory
    {
        public abstract Enemy getEnemy(GameObject obj, EnemyTypes type);
    }

    public class EnemyFactory : NPCFactory
    {
        public override Enemy getEnemy(GameObject obj, EnemyTypes type)
        {
            switch (type)
            {
                case EnemyTypes.low:
                    return obj.AddComponent<LowPowerEnemy>();
                case EnemyTypes.medium:
                    return obj.AddComponent<MediumPowerEnemy>();
                case EnemyTypes.high:
                    return obj.AddComponent<HighPowerEnemy>();
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

    public Vector3 generatePosition(float a, float b)
    {
        int enemiesCounter = (int)Random.Range(1f, 3f);
        firstLvlYPositions = new float[] {
            -2.91f, //0
            -0.91f, //1
            2.12f, //2
            -3.91f,//3
            2.09f, //4
            -6.9f, //5
            0.05f, //6
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
        float positionX;
        if (a != 0 && b != 0)
        {
            positionX = Random.Range(a, b);
        }
        else if (a == 0 && b != 0)
        {
            positionX = Random.Range(30f, b);
        }
        else if (a != 0 && b == 0)
        {
            positionX = Random.Range(a, 590f);
        }
        else
        {
            positionX = Random.Range(30f, 590f);
        }
        float positionY = 0f;
        if (positionX >= 30f && positionX <= 56f) // First Section
        {
            positionY = firstLvlYPositions[0];
        }
        else if (positionX >= 61f && positionX <= 73f)
        {
            positionY = firstLvlYPositions[1];
        }
        else if (positionX >= 77.5f && positionX <= 123f)
        {
            positionY = firstLvlYPositions[2];
        }
        else if (positionX >= 134.5f && positionX <= 205.5f)
        {
            if (positionX <= 159f)
            {
                int selecter = (int)Random.Range(0f, 1f);
                if (selecter == 0)
                {
                    positionY = firstLvlYPositions[3];
                }
                else
                {
                    positionY = firstLvlYPositions[4];
                }
            }
            else
            {
                positionY = firstLvlYPositions[3];
            }
        }
        else if (positionX >= 216f && positionX <= 227f)
        {
            positionY = firstLvlYPositions[5];
        }
        else if (positionX >= 277f && positionX <= 333f)
        {
            positionY = firstLvlYPositions[6];
        }
        else if (positionX >= 340.5f && positionX <= 354f)
        {
            positionY = firstLvlYPositions[7];
        }
        else if (positionX >= 394.5f && positionX <= 397.5f)
        {
            positionY = firstLvlYPositions[8];
        }
        else if (positionX >= 401f && positionX <= 405.5f)
        {
            positionY = firstLvlYPositions[9];
            enemiesCounter = 1;
        }
        else if ((positionX >= 412f && positionX <= 426f))
        {
            positionY = firstLvlYPositions[10];
        }
        else if (positionX >= 436.2f && positionX <= 533f)
        {
            positionY = firstLvlYPositions[10];
            if (positionX >= 455.26 && positionX <= 456.7)
            {
                int selecter = (int)Random.Range(0f, 3f);
                switch (selecter)
                {
                    case 0:
                        positionY = firstLvlYPositions[14];
                        enemiesCounter = 1;
                        break;
                    case 1:
                        positionY = firstLvlYPositions[11];
                        enemiesCounter = 1;
                        break;
                    case 2:
                        positionY = firstLvlYPositions[12];
                        enemiesCounter = 1;
                        break;
                    case 3:
                        positionY = firstLvlYPositions[10];
                        break;
                }
            }
            else if (positionX >= 470.55f && positionX <= 471.2f)
            {
                int selecter = (int)Random.Range(0f, 3f);
                switch (selecter)
                {
                    case 0:
                        positionY = firstLvlYPositions[13];
                        enemiesCounter = 1;
                        break;
                    case 1:
                        positionY = firstLvlYPositions[18];
                        enemiesCounter = 1;
                        break;
                    case 2:
                        positionY = firstLvlYPositions[14];
                        enemiesCounter = 1;
                        break;
                    case 3:
                        positionY = firstLvlYPositions[10];
                        break;
                }
            }
            else if (positionX >= 479f && positionX <= 504.29f)
            {
                int selecter = (int)Random.Range(0f, 1f);
                if (selecter == 0)
                {
                    positionY = firstLvlYPositions[5];
                    enemiesCounter = 4;
                }
                else
                {
                    positionY = firstLvlYPositions[10];
                }
            }
            else if (positionX >= 514f)
            {
                int selecter = (int)Random.Range(0f, 1f);
                if (selecter == 0)
                {
                    positionY = firstLvlYPositions[15];
                }
                else
                {
                    positionY = firstLvlYPositions[10];
                }
            }
        }
        else if (positionX >= 583f && positionX <= 604f)
        {
            positionY = firstLvlYPositions[17];
        } else
        {
            return generatePosition(0, 0);
        }

        return new Vector3(positionX, positionY, (float)enemiesCounter);
    }

}
