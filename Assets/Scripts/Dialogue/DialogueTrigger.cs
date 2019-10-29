using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    -Este script hereda de la clase Singleton para garantizar
    un único diálogo activo en cualquier momento
*/

public class DialogueTrigger : Singleton<DialogueTrigger>
{
    public Dialogue dialogue;

    //Llamar este método en el inspector del objeto o evento que activa un diálogo
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
