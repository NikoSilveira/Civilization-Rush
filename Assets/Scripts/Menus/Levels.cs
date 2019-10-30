using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    -Este script genera variables de control para transición hacia niveles
    -Se elimina Monobehaviour y se cambia a Serializable para incorporar estas 
    variables en el inspector del DialogueManager
*/

[System.Serializable]
public class Levels
{
    public int levelID;
}
