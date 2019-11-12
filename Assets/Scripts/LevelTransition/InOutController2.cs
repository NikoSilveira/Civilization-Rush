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

    //Objetos de control del UI
    public Text puntos;
    public Text record;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();

        //Inicializar datos del UI
        puntos.text = player.Score.ToString();
        record.text = PlayerPrefs.GetInt("ScoreRecord" + SceneManager.GetActiveScene().buildIndex,0).ToString();
    }


    //------------------------------------------
    //      METODOS CONTROL DE ANIMACIONES
    //------------------------------------------

    public void ShowFinishInfo()
    {
        animator.SetTrigger("ShowFinish");
        Invoke("RemoveFinishInfo", 3);
    }

    public void RemoveFinishInfo()
    {
        animator.SetTrigger("HideFinish");
    }
}
