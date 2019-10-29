using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalTrigger : MonoBehaviour
{
    [SerializeField] float SceneLoadTime = 1f;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<AudioManager>().Play("Victory");
        SceneManager.LoadScene(0);
    }

}
