using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Este script crea un objeto de tipo playerPhone para poder obtener
    los valores de resistencia del jugador y mostarlos en pantalla
 */

public class Resistance : MonoBehaviour
{
    
    //Variables para los sprites
    public Sprite[] Resistances;
    public Image resistanceUI;

    private PlayerPhone player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mantener la barra de resistencia actualizada en tiempo real
        resistanceUI.sprite = Resistances[player.myResistance];
    }
}
