using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalTrigger : MonoBehaviour
{

    private PlayerPhone player;
    private int PlayerScore;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    void Update()
    {
        PlayerScore = player.Score;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(PlayerScore >= 100)
        {
            FindObjectOfType<AudioManager>().Stop("Theme");
            FindObjectOfType<AudioManager>().Play("Victory");

            Invoke("nextScene", 6);
        }
        else
        {
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

    }

    void nextScene()
    {
        SceneManager.LoadScene(0);
    }

}
