using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Este script crea un objeto de tipo PlayerPhone para obtener 
    el valor del puntaje y mostrarlo en pantalla
 */

public class Score : MonoBehaviour
{
    
    public Text playerScore;

    public Text ScoreUi;
    private PlayerPhone player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mantener el score del jugador en tiempo real
        playerScore.text = player.Score.ToString();
    }
}
