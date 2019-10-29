using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalTrigger : MonoBehaviour
{
    [SerializeField] float SceneLoadTime = 1f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Play("Victory");

        Invoke("nextScene",6);
    }

    void nextScene()
    {
        SceneManager.LoadScene(0);
    }

}
