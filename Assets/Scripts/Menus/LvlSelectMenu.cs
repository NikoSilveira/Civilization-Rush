using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlSelectMenu : MonoBehaviour
{
    
    public void SelectLevel()
    {
        SceneManager.LoadScene(1);
    }
    

    public void Back()
    {
        //DontDestroyOnLoad();
        SceneManager.LoadScene(0);
    }
}
