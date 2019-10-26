using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearPick : MonoBehaviour
{
    private PlayerPhone player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.spearF = true;
            Destroy(gameObject);
        }
    }
}
