using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Este script crea un objeto de tipo PlayerPhone para
    poder obtener los valores de vida del jugador y mostrarlos
    en la pantalla
 */

public class Health : MonoBehaviour
{
    
    //Variables para sprites barra de salud
    public Sprite[] HearthSprices;
    public Image HearthUI;

    private PlayerPhone player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    private void Update()
    {
        //Mantener la barra de vida actualizada en tiempo real
        HearthUI.sprite = HearthSprices[player.myH];
    }
}
