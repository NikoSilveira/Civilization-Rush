using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Script de control del escudo
 * Se crea un objeto de tipo player para interactuar con las variables de escudo del jugador
 */

public class PlayerDefend : MonoBehaviour
{

    //public BoxCollider2D shieldCollider;

    private Animator animator;
    private PlayerPhone player;
    public bool shieldAnimatorLayerExists = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
        animator = GetComponent<Animator>();
        //shieldCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Solo funciona si el juego no esta pausado
        if(Time.timeScale == 1)
        {
            AnimationControl();
        }
    }


    //-------------------------------
    //    FUNCIONES PARA BOTONES
    //-------------------------------

    //Defender
    public void playerBlock()
    {
        if (!player.shieldActive && player.shield)
        {
            player.shieldActive = true;
            animator.SetBool("blocking", player.shieldActive);
            player.StopMoving();

            //shieldCollider.enabled = true;
        }
    }

    //Al dejar de defender
    public void playerDontBlock()
    {
        player.shieldActive = false;
        animator.SetBool("blocking", player.shieldActive);

        //shieldCollider.enabled = false;
    }



    //----------------------------------
    //    CONTROLADOR DE ANIMACIONES
    //----------------------------------

    void AnimationControl()
    {
        if(this.shieldAnimatorLayerExists)
        {
            if (player.shield == false)
            {
                //Activar animaciones estándar
                animator.SetLayerWeight(1, 0);
            }
            else if (player.shield == true)
            {
                //Activar animaciones con escudo
                animator.SetLayerWeight(1, 1);
            }
        }
    }


}
