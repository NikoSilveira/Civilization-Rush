using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * -Este script accede al objeto player para obtener el score
 * -Este script accede a playerprefs para obtener el record
 * -El objeto InOutController 2 es pasado por inspector al portal para
 * activar animaciones al colisionar con el portal
 * 
 * -Para asignar a otros niveles, copiar el objeto de la carpeta prefabs
 */

public class InOutController2 : MonoBehaviour
{
    
    private PlayerPhone player;
    public Animator animator;
    public GameObject mobileUI;

    //Objetos de control del UI
    public Text puntos;
    public Text record;

    //Botones UI - pasar por inspector
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }


    //------------------------------------------
    //      METODOS CONTROL DE ANIMACIONES
    //------------------------------------------

    public void ShowFinishInfo()
    {
        //Deshabilitar botones al terminar nivel
        mobileUI.SetActive(false);

        //Detener al jugador
        player.StopMoving();

        //Establecer y mostrar la info
        puntos.text = "Puntos: "+player.Score.ToString();
        record.text = "Record: "+PlayerPrefs.GetInt("ScoreRecord" + SceneManager.GetActiveScene().buildIndex).ToString();
        animator.SetTrigger("ShowFinish");
        Invoke("RemoveFinishInfo", 3);
    }

    public void RemoveFinishInfo()
    {
        animator.SetTrigger("HideFinish");
    }

}
