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
        StartCoroutine(LoadNextScene());
        Destroy(gameObject);
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSecondsRealtime(SceneLoadTime);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("MainMenu");
    }
}
