using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int attPow;
    public Animator animator;
    public Rigidbody2D enemyBody;
    public CapsuleCollider2D enemyCollider;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;
    public EnemyMovement moveController;
    public Transform target;
    public abstract void Move();
    public abstract void Attack();
    public abstract int getAttPow();
    public abstract int getHealth();
    public abstract void setHealth(int health);
    public abstract void setAttPow(int att);
    public abstract void setEnemyPosition(float x, float y, float z);
    public abstract void setBodyType(RigidbodyType2D type);
    public abstract void initAnimator();
    public abstract void setSprite(SpriteRenderer spRenderer, Sprite sprite);
    public abstract void setEnemyCollider(CapsuleCollider2D collider);
    public abstract void setMoveController(EnemyMovement moveController);
    public abstract void setTarget(Transform target);
}
