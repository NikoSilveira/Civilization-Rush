using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * -A CADA BOTON SE LE DEBE ASIGNAR ESTE SCRIPT Y LA FUNCION TRIGGERINFO
 */

public class InfoTrigger : MonoBehaviour
{
    //Crear objeto serializable Description para obtener los campos de información
    public Description description;

    //Mostrar la info correspondiente al botón pulsado en el lvlmenu
    public void TriggerInfo(int level)
    {
        FindObjectOfType<InfoManager>().ShowInfo(description, level);
    }
}
