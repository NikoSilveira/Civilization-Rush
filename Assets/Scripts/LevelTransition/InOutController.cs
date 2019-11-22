using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * -Este script controla el UI animado que se muestra al empeozar el nivel
 * -Para asignar a otros niveles, copiar el objeto de la carpeta prefabs
 */

public class InOutController : MonoBehaviour
{
    public GameObject mobileUI;

    //Objetos de control del UI
    public Animator animator;
    public Text title;
    public Text objective;

    //Objetos control UI (botones) - pasar por inspector
    public Button[] buttons;

    //Strings para modificar contenido de UI (modificar en inspector)
    public string inputTitle;
    public string inputObjective;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializar datos el UI
        title.text = inputTitle;
        objective.text = inputObjective;

        //Activar la animaciones
        Invoke("ShowInitialInfo",0.3f);
        Invoke("RemoveInitialInfo", 3.0f);

        //Arrancar con UI desactivado
        mobileUI.SetActive(false);
    }


    //------------------------------------------
    //      METODOS CONTROL DE ANIMACIONES
    //------------------------------------------

    public void ShowInitialInfo()
    {
        animator.SetTrigger("Entering");
    }

    public void RemoveInitialInfo()
    {
        animator.SetTrigger("RemoveEntering");
        Invoke("EnableButtons", 1.1f);
    }

    //Habilitar botones del UI - Invoke
    public void EnableButtons()
    {
        mobileUI.SetActive(true);
    }
}
