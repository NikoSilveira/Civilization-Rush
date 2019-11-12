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

    //Objetos de control del UI
    public Animator animator;
    public Text title;
    public Text objective;

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
    }
}
