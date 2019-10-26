using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPickup : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            /*DialogueTrigger dTrigger = GameObject.FindGameObjectWithTag("Info").GetComponent<DialogueTrigger>();
            dTrigger.TriggerDialogue();*/

            //gameObject minuscula agarra el objeto en cuestión
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();

            Destroy(gameObject);
        }
    }

}
