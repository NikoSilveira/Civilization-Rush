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
        //SFX
        FindObjectOfType<AudioManager>().Play("Press");

        //Reiniciar record por nivel - MODIFICAR SEGUN NUMERO DE NIVELES
        for (int i = 1; i < 4; i++)
        {
            PlayerPrefs.SetInt("ScoreRecord" + i, 0);
        }

        PlayerPrefs.SetInt("levelReached", 1);
        SceneManager.LoadScene(0);
    }
}
