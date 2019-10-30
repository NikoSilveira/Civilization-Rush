using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighPowerEnemy : Enemy
{
    public HighPowerEnemy()
    {
        enemyBody = new Rigidbody2D();
        boxCollider = new BoxCollider2D();
        setAttPow(5);
        setHealth(9);
    }
    public override void Move()
    {
        moveController.Move(enemyBody);
    }
    public override void Attack()
    {
    }
    public override int getAttPow()
    {
        return this.attPow;
    }
    public override int getHealth()
    {
        return this.health;
    }
    public override void setHealth(int health)
    {
        this.health = health;
    }
    public override void setAttPow(int att)
    {
        this.attPow = att;
    }
    public override void setEnemyPosition(float x, float y, float z)
    {
        this.enemyBody.position = new Vector3(x, y, z);
    }
    public override void setBodyType(RigidbodyType2D type)
    {
        this.enemyBody = GetComponent<Rigidbody2D>();
        this.enemyBody.bodyType = type;
    }
    public override void initAnimator()
    {
        this.animator = GetComponent<Animator>();
    }
    public override void setSprite(SpriteRenderer spRenderer, Sprite sprite)
    {
        this.spriteRenderer = spRenderer;
        this.spriteRenderer.sortingLayerName = "Enemy";
        this.spriteRenderer.sprite = sprite;
    }
    public override void setEnemyCollider(CapsuleCollider2D collider)
    {
        this.enemyCollider = collider;
        this.enemyCollider.size = new Vector2(2.19f, 2.19f);
    }
    public override void setMoveController(EnemyMovement moveController)
    {
        this.moveController = moveController;
    }
    public override void setTarget(Transform target)
    {
        this.moveController.setTarget(target);
    }
}
