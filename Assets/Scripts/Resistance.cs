using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resistance : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] Resistances;

    public Image resistanceUI;
    private PlayerPhone player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
    }

    // Update is called once per frame
    void Update()
    {
        resistanceUI.sprite = Resistances[player.myResistance];
    }
}
