using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        //Aqui se puede implementar un singleton
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
