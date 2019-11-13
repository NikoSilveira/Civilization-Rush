using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowCuantity : MonoBehaviour
{
    public Text arrows;
    private PlayerPhone player;

    // Start is called before the first frame update
    void Start()
    {
        //arrows.setActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    // Update is called once per frame
    void Update()
    {
        arrows.text = player.arrowCan.ToString();
    }
}
