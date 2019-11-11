using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * -Este script funciona como manejador de la info mostrada por los botones de info en el menu lvlmenu
 * -Según el boton pulsado, dialogueTrigguer pasa la info correspondiente y este script 
 * se encarga de asignarla a los cuadros de texto correspondientes
 * -A CADA BOTON SE LE DEBE ASIGNAR EL SCRIPT TRIGGER Y LA FUNCION TRIGGER
 */

public class InfoManager : MonoBehaviour
{

    //Estas variables son de tipo cuadro de texto
    //se pasan los correspondientes objetos de texto por el inspector
    public Text Title;
    public Text Objetivo;
    public Text Record;
    public Text Dificultad;
    public Text Informacion;


    //Pasar la info recibida del script trigger a los cuadros de texto de la vista de info
    public void ShowInfo(Description description, int level)
    {
        //El record se obtiene el archivo local
        int record = PlayerPrefs.GetInt("ScoreRecord"+level, 0);

        Title.text = description.title;
        Objetivo.text = description.varObjetivo;
        Record.text = record.ToString();
        Dificultad.text = description.varDificultad;
        Informacion.text = description.varInformacion;
    }
}
