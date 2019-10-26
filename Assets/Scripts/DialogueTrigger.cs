using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Singleton<DialogueTrigger>
{
    //Hereda Singleton

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
