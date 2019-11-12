using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistanceCapsulle : MonoBehaviour
{
    private PlayerPhone player;

    //Cantidad de resistencia a recuperar
    public int resistanceObtained;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.myResistance + resistanceObtained > 5)
            {
                //Recuperar solo lo que falta de resistencia si al obtener lo que da la botella supera la resistencia maxima del jugador
                player.myResistance += (5 - player.myResistance);
                Destroy(gameObject);
            }
            else if (player.myResistance + resistanceObtained <= 5)
            {
                //Recuperar resistencia (valor completo de la botella)
                player.myResistance += resistanceObtained;
                Destroy(gameObject);
            }

            //SFX
            FindObjectOfType<AudioManager>().Play("Drink");
        }
    }

}
