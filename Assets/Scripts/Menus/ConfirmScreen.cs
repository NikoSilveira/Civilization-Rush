using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmScreen : MonoBehaviour
{

    //Objetos tipo panel
    public GameObject SettingsMenuPanel;
    public GameObject ConfirmPanel;

    //Volver a la pantalla de ajustes
    public void Back()
    {
        ConfirmPanel.SetActive(false);
        SettingsMenuPanel.SetActive(true);

        //SFX
        FindObjectOfType<AudioManager>().Play("Press");
    }

    //Confirmar y borrar los datos guardados (solo rebloquea niveles)
    public void Confirm()
    {
        PlayerPrefs.SetInt("levelReached", 1);
        SceneManager.LoadScene(0);

        //SFX
        FindObjectOfType<AudioManager>().Play("Press");
    }
}
