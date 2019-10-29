using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        animator.SetBool("IsOpen", true);   //Mostrar cuadro de diálogo

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
        if (sentences.Count == 0)
        {
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

}
