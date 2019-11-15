using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * -Controlador de transición entre niveles
 * -Se hereda de la clase Singleton para garantizar un solo controlador de niveles
 */

public class LevelChanger : Singleton<LevelChanger>
{

    public Animator animator;
    private int levelToLoad;

    // Update is called once per frame
    void Update()
    {

    }



    //-----------------------------
    //      CONTROL DEL FADE
    //-----------------------------

    //Obtener el proximo nviel para transición
    public void FadeToNextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            //Ultimo nivel - fade to title screen
            FadeToLevel(0);
        }
        else
        {
            //next level
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //Activar fade
    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    //Cambiar de nivel
    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
