using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * -Este script genera campos para llenar con la informacion de cada epoca en el inspector
 * -Un objeto del tipo de este script es creado en el script InfoTrigger
 */

[System.Serializable]
public class Description
{
    //Crear cuadros para texto en el inspector
    public string title;
    public string varObjetivo;
    public string varRecord;
    public string varDificultad;

    [TextArea(1, 20)]
    public string varInformacion;

}
