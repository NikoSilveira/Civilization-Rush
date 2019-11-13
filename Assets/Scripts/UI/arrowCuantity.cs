using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowCuantity : MonoBehaviour
{
    public Text arrows;
    private PlayerPhone player;
    private PlayerAttack player2;

    // Start is called before the first frame update
    void Start()
    {
        arrows.text = "";
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
        player2 = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player2.weaponSelected == 3)
        {
            arrows.text = player.arrowCan.ToString();
        }
        else
        {
            arrows.text = "";
        }
        
    }
}
