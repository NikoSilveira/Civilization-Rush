using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPickup : MonoBehaviour
{

    PlayerPhone PlayerP;
    //DialogueTrigger dTrigger;

    // Start is called before the first frame update
    void Start()
    {
        PlayerP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
        //dTrigger = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueTrigger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Cero0");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Uno1");
            DialogueTrigger dTrigger = GameObject.FindGameObjectWithTag("Book").GetComponent<DialogueTrigger>();
            Debug.Log("Dos2");
            dTrigger.TriggerDialogue();
            Debug.Log("Tres3");
            Destroy(gameObject);
        }
    }

}
