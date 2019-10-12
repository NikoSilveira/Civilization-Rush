using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigiBody;
    // Start is called before the first frame update
    void Start()
    {
        myRigiBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight()) 
        {
            myRigiBody.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            myRigiBody.velocity = new Vector2(-moveSpeed, 0);
        }
        
    }

   bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigiBody.velocity.x)), 1f);
    }
}
