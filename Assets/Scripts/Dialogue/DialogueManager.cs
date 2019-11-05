using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    -Este script crea un objeto de tipo playerphone para utilizar los setters del personaje
    y poder validar su comportamiento al activar/desactivar dialogos
 */

public class DialogueManager : MonoBehaviour
{

    //Título y texto del dialogo
    public Text nameText;
    public Text dialogueText;

    //Animador para efectos del cuadro de diálogo
    public Animator animator;

    //Cola FIFO para las oraciones
    private Queue<string> sentences;

    //Objeto jugador
    private PlayerPhone player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
        sentences = new Queue<string>();
    }



    //-------------------------------------
    //  MÉTODOS PARA CONTROL DE DIÁLOGOS
    //-------------------------------------

    //Comenzar el dialogo
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);   //Mostrar cuadro de diálogo

        //Pausar el juego
        Invoke("Delay", 1);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            //Encolar oraciones
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    //Llamar la siguiente oración en la cola
    public void DisplayNextSentence()
    {
        //Finalizar si no quedan mas oraciones
        if (sentences.Count == 0)
        {
            Time.timeScale = 1;
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    //Finalizar el dialogo
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);  //Esconder cuadro de diálogo
    }

    //Pausar el juego al mostrar cuadro de dialogo
    void Delay()
    {
        Time.timeScale = 0;
        player.StopMoving();
    }

}
