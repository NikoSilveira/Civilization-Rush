using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //Variables para loading bar
    public GameObject loadingScreen;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Funcion para selección de nivel
    public void SelectLevel(int levelID)
    {
        StartCoroutine(LoadAsync(levelID));
    }

    //Funcion asincrona para cargar nivel
    IEnumerator LoadAsync(int levelID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelID);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            //Obtener el progreso y pasarlo a la barra
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;
        }
    }
}
