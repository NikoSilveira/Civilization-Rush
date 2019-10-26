using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Spikes : MonoBehaviour
{
    private PlayerPhone player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.takeDamage(1);

            StartCoroutine(player.Knockback(0.2f, 250, player.transform.position));
        }
    }
}
