using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCapsule : MonoBehaviour
{
    private PlayerPhone player;
    public int lifeObtained = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(player.myHealth + lifeObtained > 9)
            {
                player.myHealth += (9 - player.myHealth);
                Destroy(gameObject);
            }else if(player.myHealth + lifeObtained <= 9)
            {
                player.myHealth += lifeObtained;
                Destroy(gameObject);
            }
        }
    }
}
