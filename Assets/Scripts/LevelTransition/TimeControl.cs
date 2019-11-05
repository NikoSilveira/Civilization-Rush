using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  -Este script se usa para control del tiempo en eventos de animador
 *  -Se crea un objeto de tipo playerphone para poder realizar validaciones
 *  sobre el movimiento y comportamiento del jugador al detener y reanudar el flujo de tiempo
 */

public class TimeControl : MonoBehaviour
{

    private PlayerPhone player;

    void Start()
    {
        //Obtener el objeto player de unity
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }


    public void StopTime()
    {
        Time.timeScale = 0;
        player.StopMoving();
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }
}
