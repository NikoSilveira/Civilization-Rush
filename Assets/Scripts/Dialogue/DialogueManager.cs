using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *  -Controlador de dialogos
 *  -El tiempo es detenido con el script TimeControl usando un evento en el animador
 *  -El tiempo es reanudado en este script al vaciar la cola de oraciones y terminar el dialogo
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


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }



    //-------------------------------------
    //  MÉTODOS PARA CONTROL DE DIÁLOGOS
    //-------------------------------------

    //Comenzar el dialogo
    public void StartDialogue(Dialogue dialogue)
    {
        //Mostrar cuadro de diálogo
        animator.SetBool("IsOpen", true);

        //Detener timescale al salir dialogo
        Invoke("StopTime",0.3f);

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

    private void StopTime()
    {
        Time.timeScale = 0;
    }

}
