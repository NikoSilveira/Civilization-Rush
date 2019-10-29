using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    -Este script genera variables de control del cuadro de diálogo
    -Se elimina Monobehaviour y se cambia a Serializable para incorporar estas 
    variables en el inspector del DialogueManager
*/

[System.Serializable]
public class Dialogue
{

    public string name;

    //TextArea establece min y max de lineas por diálogo
    [TextArea(1,5)]
    public string[] sentences;

}
