using UnityEngine;
using UnityEngine.SceneManagement;

/*
    -Script de control del menú de selección de niveles
 */

public class LvlSelectMenu : MonoBehaviour
{
    //Pasar de nivel (paso de parametro por inspector)
    public void SelectLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }

    //Volver al menú principal
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
